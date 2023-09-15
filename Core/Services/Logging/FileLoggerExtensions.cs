using Core.Services.Events;
using Microsoft.Extensions.Logging;

namespace Core.Services.Logging;

public static class LoggerExtensions
{
    public static ILoggingBuilder AddDatabaseLogging(this ILoggingBuilder builder, EventMainService eventMainService)
    {
        builder.AddProvider(new DbLoggerProvider(eventMainService));
        return builder;
    }
}
