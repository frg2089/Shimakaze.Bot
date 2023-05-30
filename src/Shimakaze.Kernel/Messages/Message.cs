namespace Shimakaze.Kernel.Messages;

public abstract record Message
{
    public DateTime Time { get; protected init; }

    public uint Sequence { get; protected init; }

    public long Uuid { get; protected init; }

    public uint Random { get; protected init; }

    public SourceType Type { get; protected init; }
    public UserInfo Sender { get; protected init; }
    public UserInfo Receiver { get; protected init; }
    public MessageContent? Content { get; protected init; }
}
