namespace Shimakaze.Kernel.Messages.Spans;

public abstract record TextSpanBase : MessageSpan
{
    public string Content { get; protected init; } = string.Empty;
}
