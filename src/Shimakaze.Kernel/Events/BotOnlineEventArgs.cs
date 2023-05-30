namespace Shimakaze.Kernel.Events;

public enum OnlineType
{
    FirstOnline,
    ConnectionReset
}

public abstract class BotOnlineEventArgs : BotEventArgs
{
    public OnlineType Type { get; protected init; }
    protected BotOnlineEventArgs(object raw) : base(raw)
    {
    }
}
