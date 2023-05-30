namespace Shimakaze.Kernel.Messages.Spans;

public abstract record FileSpan : MessageSpan
{
    protected FileSpan()
    {
        Mode = MessageSpanMode.Singleton;
    }

    public string Name { get; protected init; } = string.Empty;
    public ulong Size { get; protected init; }
    public string Url { get; protected init; } = string.Empty;
    public byte[] Hash { get; protected init; } = Array.Empty<byte>();
}
