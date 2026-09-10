using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Activity
{

    public interface IActivityLogService
    {
        void Log(LogLevel level, string source, string message);
        void LogError(string source, string message, Exception? ex = null);

        IReadOnlyList<ActivityLogEntry> GetHistory();

        event EventHandler<ActivityLogEntry>? EntryAdded;
    }

    public class ActivityLogService : IActivityLogService
    {
        private readonly List<ActivityLogEntry> _entries = new();
        private readonly object _lock = new();

        // Храним только последние 1000 записей
        private const int MaxCapacity = 1000;

        public event EventHandler<ActivityLogEntry>? EntryAdded;

        public void Log(LogLevel level, string source, string message)
        {
            var entry = new ActivityLogEntry
            {
                Level = level,
                Source = source,
                Message = message
            };

            lock (_lock)
            {
                _entries.Add(entry);
                if (_entries.Count > MaxCapacity)
                {
                    _entries.RemoveAt(0);
                }
            }

            // Избежать deadlocks
            EntryAdded?.Invoke(this, entry);
        }

        public void LogError(string source, string message, Exception? ex = null)
        {
            var fullMessage = ex != null ? $"{message}\n{ex}" : message;
            Log(LogLevel.Error, source, fullMessage);
        }

        public IReadOnlyList<ActivityLogEntry> GetHistory()
        {
            lock (_lock)
            {
                // Возвращаем копию, чтобы избежать проблем при итерации в UI
                return _entries.ToList().AsReadOnly();
            }
        }
    }
}
