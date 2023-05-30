namespace Shimakaze.Kernel.Messages.Spans;

public abstract record ReplySpan : MessageSpan
{
    protected ReplySpan()
    {
        Mode = MessageSpanMode.Singletag;
    }

    public uint Id { get; protected init; }
    public uint Sequence { get; protected init; }
    public long Uuid { get; protected init; }
    public uint Time { get; protected init; }
    public string Preview { get; protected init; } = string.Empty;
}
