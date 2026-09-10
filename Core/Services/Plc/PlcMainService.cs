using Core.Infrastructure.DataAccess.Repositories;
using Core.Models.Plc;
using Core.Services.Activity;
using Core.Services.Communication;
using Core.ViewModels;
using System.Text;

namespace Core.Services.Plc
{
    public class PlcMainService
    {
        public event Action ScanCompletedEvent;
        public PlcModel PlcModel { get; } = new PlcModel();
        public event Action<string> LogEvent = delegate { };
        public PlcStateInfo PlcStateInfo { get; } = new PlcStateInfo();
        public PlcConnectSettings PlcConnectSettings { get; private set; } = new PlcConnectSettings();

        private ModbusCommunicationService? _communicationService;
        private readonly IRepository<PlcConnectSettings> _connectSettingsRepository;

        private readonly IActivityLogService _logService;

        public PlcMainService(IRepository<PlcConnectSettings> connectSettingsRepository, IActivityLogService logService)
        {
            _connectSettingsRepository = connectSettingsRepository;
            _logService = logService;
            InitAsync();
        }

        private Queue<Action> WriteCommands { get; } = new Queue<Action>();

        public async void InitAsync()
        {
            var connectSetts = await _connectSettingsRepository.InitAsync(PlcDataFactory.GetConnectSettings(), 1);
            PlcConnectSettings = connectSetts.First();
            if (PlcConnectSettings != null && PlcConnectSettings.EthernetSettings != null)
            {
                _communicationService = new ModbusCommunicationService(PlcConnectSettings.EthernetSettings);
                _communicationService.LogEvent += LogEvent;                
                await ReadProcess();
            }
            else
            {
                LogEvent?.Invoke("Ошибка инициализации настроек связи с ПЛК");
            }
            

        }

        public void WriteParameter(object parameter)
        {
            if (parameter is Parameter<short> parShort && parShort.ValidationOk)
            {
                parShort.IsWriting = true;
                WriteCommands.Enqueue(new Action(() =>
                {
                    var bytes = BitConverter.GetBytes(parShort.WriteValue);
                    _communicationService?.WriteRegisters(new ushort[] { BitConverter.ToUInt16(bytes) }, parShort.ModbusRegNum);
                }));
                _logService.Log(Core.Services.Activity.LogLevel.Info, parShort.Description!, $"Изменено значение оператором на {parShort.WriteValue}");
            }
            else if (parameter is Parameter<ushort> parUShort && parUShort.ValidationOk)
            {
                parUShort.IsWriting = true;
                WriteCommands.Enqueue(new Action(() =>
                {
                    _communicationService?.WriteRegisters(new ushort[] { parUShort.WriteValue }, parUShort.ModbusRegNum);
                }));
                _logService.Log(Core.Services.Activity.LogLevel.Info, parUShort.Description!, $"Изменено значение оператором на {parUShort.WriteValue}");
            }
            else 
                if (parameter is Parameter<bool> parBool)
            {
                parBool.IsWriting = true;
                WriteCommands.Enqueue(new Action(() =>
                {
                    var reg = _communicationService.ReadHoldingRegisters(parBool.ModbusRegNum, 1).First();
                    SetBit(ref reg, parBool.ModbusBitNum, parBool.WriteValue);
                    _communicationService?.WriteRegisters(new ushort[] { reg }, parBool.ModbusRegNum);
                }));
                    _logService.Log(Core.Services.Activity.LogLevel.Info, parBool.Description!, $"Изменено значение оператором на {parBool.WriteValue}");
                }
            else if (parameter is Parameter<string> parString)
            {
                parString.IsWriting = true;
                var bytes = Encoding.ASCII.GetBytes(parString.WriteValue).
                    Take(Math.Min(parString.WriteValue.Length, parString.Length))
                    .Append((byte)0)
                    .ToArray();
                var regs = new ushort[(bytes.Length + 1) / 2];
                for (int i = 0; i < bytes.Length; i += 2)
                {
                    if (i + 1 == bytes.Length)
                        regs[i / 2] = (ushort)bytes[i];
                    else regs[i / 2] = BitConverter.ToUInt16(bytes, i);
                }
                _communicationService?.WriteRegisters(regs, parString.ModbusRegNum);
                    _logService.Log(Core.Services.Activity.LogLevel.Info, parString.Description!, $"Изменено значение оператором на {parString.WriteValue}");
                }
            else if (parameter is Parameter<float> parFloat && parFloat.ValidationOk)
            {
                parFloat.IsWriting = true;
                WriteCommands.Enqueue(new Action(() =>
                {
                    // Получаем 4 байта float
                    byte[] floatBytes = BitConverter.GetBytes(parFloat.WriteValue);

                    // Проверяем порядок байтов системы
                    if (BitConverter.IsLittleEndian)
                    {
                        Array.Reverse(floatBytes);
                    }

                    // Разбиваем 4 байта на 2 регистра по 2 байта (Big-Endian)
                    ushort[] registers = new ushort[2];
                    registers[0] = (ushort)((floatBytes[0] << 8) | floatBytes[1]); // Старший регистр
                    registers[1] = (ushort)((floatBytes[2] << 8) | floatBytes[3]); // Младший регистр

                    // Записываем 2 регистра, начиная с адреса parFloat.ModbusRegNum
                    _communicationService?.WriteRegisters(registers, parFloat.ModbusRegNum);
                }));
                    _logService.Log(Core.Services.Activity.LogLevel.Info, parFloat.Description!, $"Изменено значение оператором на {parFloat.WriteValue}");
            }
        }

        async Task ReadProcess()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(5000);
                while (_communicationService != null)
                {

                    try
                    {
                        
                        PlcStateInfo.Connected = _communicationService.Connected;
                        if (!PlcStateInfo.Connected)
                            Thread.Sleep(2000);
                        while (WriteCommands.Count > 0)
                        {
                            var cmd = WriteCommands.Dequeue();
                            cmd.Invoke();
                            _communicationService.WriteCoil(0, true);
                        }
                        GetModbusCommandService.ScanInfoFromPlc(PlcModel, _communicationService);
                        ScanCompletedEvent?.Invoke();
                        Thread.Sleep(PlcConnectSettings.ScanFrequence);

                    }
                    catch (Exception ex)
                    {

                        LogEvent?.Invoke(ex.Message);
                    }
                }
            });
        }

        public async Task SaveConnectSettingsAsync()
        {

            try
            {
                await _connectSettingsRepository.UpdateAsync(PlcConnectSettings);
                LogEvent?.Invoke("Сохранение настрок связи с ПЛК выполнено успешно");
            }
            catch (Exception ex)
            {
                LogEvent?.Invoke(ex.Message);
            }


        }

        public static void SetBit(ref ushort aByte, int pos, bool value)
        {
            if (value)
            {
                //left-shift 1, then bitwise OR
                aByte = (ushort)(aByte | (1 << pos));
            }
            else
            {
                //left-shift 1, then take complement, then bitwise AND
                aByte = (ushort)(aByte & ~(1 << pos));
            }
        }


        //private void SynchroTime()
        //{
        //    var dt = DateTime.Now;
        //    PlcModel.Settings.DateSynchroYear.WriteValue = (short)(dt.Year - 2000);
        //    PlcModel.Settings.DateSynchroMonth.WriteValue = (short)(dt.Month);
        //    PlcModel.Settings.DateSynchroDay.WriteValue = (short)(dt.Day);
        //    PlcModel.Settings.DateSynchroHour.WriteValue = (short)(dt.Hour);
        //    PlcModel.Settings.DateSynchroMin.WriteValue = (short)(dt.Minute);
        //    PlcModel.Settings.DateSynchroSec.WriteValue = (short)(dt.Second);
        //    PlcModel.Settings.DateSynchroDayOfWeek.WriteValue = (short)(dt.DayOfWeek + 1);
        //    PlcModel.ButtonCommandsModel.TimeSynchroCmd.WriteValue = true;

        //    WriteParameter(PlcModel.Settings.DateSynchroYear);
        //    WriteParameter(PlcModel.Settings.DateSynchroMonth);
        //    WriteParameter(PlcModel.Settings.DateSynchroDay);
        //    WriteParameter(PlcModel.Settings.DateSynchroHour);
        //    WriteParameter(PlcModel.Settings.DateSynchroMin);
        //    WriteParameter(PlcModel.Settings.DateSynchroSec);
        //    WriteParameter(PlcModel.Settings.DateSynchroDayOfWeek);
        //    WriteParameter(PlcModel.ButtonCommandsModel.TimeSynchroCmd);
        //}






    }


}
