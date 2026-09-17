using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; init; } = DateTime.Now;
        [JsonPropertyName("level")]
        public LogLevel Level { get; init; }
        [JsonPropertyName("source")]
        public string Source { get; init; } = string.Empty; 
        [JsonPropertyName("message")]
        public string Message { get; init; } = string.Empty;
    }
}
