namespace Shimakaze.Kernel.Messages.Spans;
public abstract record VideoSpan : MessageSpan
{
    protected VideoSpan()
    {
        Mode = MessageSpanMode.Singleton;
    }

    public string Url { get; protected init; } = string.Empty;
    public string Name { get; protected init; } = string.Empty;
    public string Hash { get; protected init; } = string.Empty;
    public string Path { get; protected init; } = string.Empty;
    public uint Width { get; protected init; }
    public uint Height { get; protected init; }
    public uint Duration { get; protected init; }

}