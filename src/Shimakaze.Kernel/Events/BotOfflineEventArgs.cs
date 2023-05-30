namespace Shimakaze.Kernel.Events;

public enum OfflineType
{
    UserLoggedOut,
    ServerKickOff,
    NetworkDown
}

public abstract class BotOfflineEventArgs : BotEventArgs
{
    public OfflineType Type { get; protected init; }
    protected BotOfflineEventArgs(object raw) : base(raw)
    {
    }
}
