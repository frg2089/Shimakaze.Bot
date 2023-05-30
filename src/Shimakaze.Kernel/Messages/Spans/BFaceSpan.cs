namespace Shimakaze.Kernel.Messages.Spans;

public abstract record BFaceSpan : MessageSpan
{
    protected BFaceSpan()
    {
        Mode = MessageSpanMode.Singleton;
    }

    public string Name { get; protected init; } = string.Empty;
    public uint Id { get; protected init; }
    public byte[] Hash { get; protected init; } = Array.Empty<byte>();

}
