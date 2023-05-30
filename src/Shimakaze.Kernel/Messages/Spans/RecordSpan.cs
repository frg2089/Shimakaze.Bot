namespace Shimakaze.Kernel.Messages.Spans;

public enum RecordType
{
    Amr = 0,
    Silk = 1,
}

public abstract record RecordSpan : MessageSpan
{
    protected RecordSpan()
    {
        Mode = MessageSpanMode.Singleton;
    }

    public uint Id { get; protected init; }
    public string Name { get; protected init; } = string.Empty;
    public byte[] Hash { get; protected init; } = Array.Empty<byte>();
    public byte[] Data { get; protected init; } = Array.Empty<byte>();
    public uint Length { get; protected init; }
    public uint TimeSeconds { get; protected init; }
    public RecordType Type { get; protected init; }
}
