using Core.Services.Events;
using Microsoft.Extensions.Logging;

namespace Core.Services.Logging
{
    public class DbLoggerProvider : ILoggerProvider
    {
        private readonly EventMainService _eventMainService;

        public DbLoggerProvider(EventMainService eventMainService)
        {
            _eventMainService = eventMainService;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new DbLogger(_eventMainService);
        }

        public void Dispose() { }
    }
}
