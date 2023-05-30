using Konata.Core.Events;

using Shimakaze.Kernel.Events;

namespace Shimakaze.Konata.Events;

public sealed class KonataBotLogEventArgs : LogEventArgs
{
    public KonataBotLogEventArgs(LogEvent raw) : base(raw)
    {
        Time = raw.EventTime;
        Level = raw.Level switch
        {
            LogLevel.Verbose => Microsoft.Extensions.Logging.LogLevel.Debug,
            LogLevel.Information => Microsoft.Extensions.Logging.LogLevel.Information,
            LogLevel.Warning => Microsoft.Extensions.Logging.LogLevel.Warning,
            LogLevel.Exception => Microsoft.Extensions.Logging.LogLevel.Error,
            LogLevel.Fatal => Microsoft.Extensions.Logging.LogLevel.Critical,
            _ => Microsoft.Extensions.Logging.LogLevel.Trace,
        };
        Category = raw.Tag;
        Description = raw.EventMessage;
    }
}