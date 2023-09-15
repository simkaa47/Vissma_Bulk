using Core.Models.AccesControl;
using Core.Models.Events;
using Core.Services.Events;
using Microsoft.Extensions.Logging;

namespace Core.Services.Logging
{
    public class DbLogger : ILogger, IDisposable
    {
        private readonly EventMainService _eventMainService;
        static object _lock = new object();

        public DbLogger(EventMainService eventMainService)
        {
            _eventMainService = eventMainService;
        }
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return this;
        }

        public void Dispose() { }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public async void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (eventId != 0 || state is null) return;
            if (_eventMainService == null) return;

            var historyItem = new EventHistoryItem
            {
                AccessLevel = logLevel == LogLevel.Error ? UserAccessLevel.Admin : UserAccessLevel.Admin,
                Date = DateTime.Now,
                Message = state.ToString(),
                EventType = EventType.Event               

            };
            
            try
            {
                await _eventMainService.AddHistoryItem(historyItem);
            }
            catch (Exception) { }
        }
    }
}
