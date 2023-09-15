using Core.Models.Communication;
using EasyModbus;

namespace Core.Services.Communication
{
    public class ModbusCommunicationService
    {
        private ModbusClient _client = new ModbusClient();
        public event Action<string> LogEvent = delegate { };
        public ModbusCommunicationService(EthernetSettings settings)
        {
            Settings = settings;
        }

        public bool Connected { get;private set; }

        public EthernetSettings Settings { get; }

        public List<ushort> ReadHoldingRegisters(int startRegNum, int regCnt)
        {
            try
            {
                if(_client  == null) throw new Exception("Modbus client is null");
                if(!_client.Connected)
                    Connect();
                return _client.ReadHoldingRegisters(startRegNum, regCnt).Select(i=>(ushort)i).ToList();

            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        public List<ushort> ReadReadingRegisters(int startRegNum, int regCnt)
        {
            try
            {
                if (_client == null) throw new Exception("Modbus client is null");
                if (!_client.Connected)
                    Connect();
                return _client.ReadInputRegisters(startRegNum, regCnt).Select(i => (ushort)i).ToList();

            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        public void WriteRegisters(ushort[] buf, int startRegNum)
        {
            try
            {
                if (_client == null) throw new Exception("Modbus client is null");
                if (!_client.Connected)
                    Connect();
                var regs = buf.Select(i => (int)i).ToArray();
                _client.WriteMultipleRegisters(startRegNum, regs);

            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        public void WriteCoil(int coilNumber, bool value)
        {
            try
            {
                if (_client == null) throw new Exception("Modbus client is null");
                if (!_client.Connected)
                    Connect();
                _client.WriteSingleCoil(coilNumber, value);
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        private void Connect()
        {
            _client = new ModbusClient();
            _client.IPAddress = Settings.Ip;
            _client.Port = Settings.Port;
            LogEvent?.Invoke($"Выполняется подключение к Modbus серверу по адресу {Settings.Ip}:{Settings.Port}");
            _client.Connect();
            Connected = _client.Connected;
            if(Connected)
            {
                LogEvent?.Invoke($"Подключение к Modbus серверу по адресу {Settings.Ip}:{Settings.Port} выполнено успешно");
            }
        }

        private void Disconnect() 
        { 
            if(_client != null && _client.Connected)
            {
                LogEvent?.Invoke($"Выполняется отключение от {_client.IPAddress}:{_client.Port}");
                _client.Disconnect();
                LogEvent?.Invoke($"Отключение от {_client.IPAddress}:{_client.Port}  выполнено успешно");
                Connected = _client.Connected;
            }
        }




    }
}
