using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Activity
{
    public enum LogLevel
    {
        Debug,
        Info,
        Warning,
        Error
    }

    public class ActivityLogEntry
    {
        public DateTime Timestamp { get; init; } = DateTime.Now;
        public LogLevel Level { get; init; }
        public string Source { get; init; } = string.Empty; // Кто записал (имя ViewModel или сервиса)
        public string Message { get; init; } = string.Empty;
    }
}
