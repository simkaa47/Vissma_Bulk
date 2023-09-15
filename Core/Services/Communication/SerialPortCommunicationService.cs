using Core.Contracts.Connect;
using Core.Models.Communication;
using System.IO.Ports;

namespace Core.Services.Communication
{
    public class SerialPortCommunicationService : IConnectService
    {
        public bool Connected { get ; set ; }
        public ComPortSettings ComPortSettings { get; }
        public SerialPort _serialPort = new SerialPort();

        public event Action<string>? LogEvent;

        public SerialPortCommunicationService(ComPortSettings comPortSettings)
        {
            ComPortSettings = comPortSettings;
        }

        public async Task<int> SendAndGetAnswerAsync(byte[] request, int requestLength, byte[] answer)
        {
            try
            {
                if (_serialPort is null) throw new Exception("Serial port is null");
                if (!_serialPort.IsOpen)
                    Connect();
                _serialPort.Write(request, 0, requestLength);
                int num = 0;
                int offset = 0;
                do
                {
                    num = _serialPort.Read(answer, offset, answer.Length - offset);
                    offset += num;
                } while (_serialPort.BytesToRead > 0 && answer.Length - offset>0);
                return offset;
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        public void Disconnect()
        {
            if(_serialPort != null && _serialPort.IsOpen)
            {
                LogEvent?.Invoke($"Выполняется закрытие серийного порта  {_serialPort.PortName}");
                _serialPort.Close();
                Connected = _serialPort.IsOpen;
            }
        }

        public void Connect()
        {
            LogEvent?.Invoke($"Выполняется открытие серийного порта  {ComPortSettings.ComPortName}");
            _serialPort = new SerialPort();
            _serialPort.Parity = ComPortSettings.Parity;
            _serialPort.BaudRate = ComPortSettings.Baudrate;
            _serialPort.PortName = ComPortSettings.ComPortName;
            _serialPort.ReadTimeout = 500;
            _serialPort.WriteTimeout = 500;
            _serialPort.Open();
            Connected = _serialPort.IsOpen;
        }
    }
}
