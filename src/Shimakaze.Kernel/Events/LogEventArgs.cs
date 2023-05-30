using Microsoft.Extensions.Logging;

namespace Shimakaze.Kernel.Events;

public abstract class LogEventArgs : BotEventArgs
{
    protected LogEventArgs(object raw) : base(raw)
    {
    }

    public LogLevel Level { get; protected init; }
    public string Category { get; protected init; } = string.Empty;
}
