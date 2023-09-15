using Core.Contracts.Connect;
using Core.Models.Communication;
using System.Net.Sockets;

namespace Core.Services.Communication
{
    public class TcpCommunicationService : IConnectService
    {
        public TcpCommunicationService(EthernetSettings settings)
        {
            Settings = settings;
        }
        public bool Connected { get; set; }
        public EthernetSettings Settings { get; }

        public event Action<string>? LogEvent;

        private NetworkStream? _stream;
        private TcpClient? _tcpClient = new TcpClient();


        public async Task<int> SendAndGetAnswerAsync(byte[] request, int requestLength, byte[] answer)
        {
            try
            {
                if (_tcpClient == null) throw new Exception("Tcp client is null");
                if (!_tcpClient.Connected)
                    await ConnectAsync();
                _stream?.Write(request, 0, requestLength);
                int num = 0;
                int offset = 0;
                do
                {
                    num = await _stream.ReadAsync(answer, offset, answer.Length - offset);
                    offset += num;

                } while (_stream.DataAvailable && answer.Length - offset > 0);
                return offset;
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        public async Task ConnectAsync()
        {
            LogEvent?.Invoke($"Выполняется подключение по адресу {Settings.Ip}:{Settings.Port}");
            _tcpClient = new TcpClient();
            if (_tcpClient != null)
            {
                _tcpClient.ReceiveTimeout = Settings.ReceiveTimeout;
                _tcpClient.SendTimeout = Settings.SendTimeout;
                await _tcpClient.ConnectAsync(Settings.Ip, Settings.Port);
                _stream = _tcpClient?.GetStream();
                if (_tcpClient != null) Connected = _tcpClient.Connected;
            }
        }

        public void Disconnect()
        {
            if (_tcpClient != null && _tcpClient.Connected)
            {
                LogEvent?.Invoke($"Выполняется отключение от адреса {_tcpClient.Client.LocalEndPoint}"); ;
                _tcpClient.Close();
                Connected = _tcpClient.Connected;
            }
        }
    }
}
