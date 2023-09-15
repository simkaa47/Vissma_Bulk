using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.Contracts.Connect
{
    public interface IConnectService
    {        
        Task<int> SendAndGetAnswerAsync(byte[] request, int requestLength, byte[] answer);
        
        bool Connected { get; set; }
        event Action<string>? LogEvent;
    }
}
