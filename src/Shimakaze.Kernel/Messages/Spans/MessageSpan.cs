namespace Shimakaze.Kernel.Messages.Spans;

public enum MessageSpanMode
{
    Multiple,
    Singleton,
    Singletag
}

public abstract record MessageSpan
{
    public MessageSpanMode Mode { get; protected init; }
}
