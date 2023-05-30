namespace Shimakaze.Kernel.Events;

public abstract class FriendRequestEventArgs : BotEventArgs, IRequestEventArgs
{
    public uint ReqId { get; protected init; }
    public string ReqName { get; protected init; } = string.Empty;
    public uint ReqTime { get; protected init; }
    public string ReqComment { get; protected init; } = string.Empty;
    public long Token { get; protected init; }
    protected FriendRequestEventArgs(object raw) : base(raw)
    {
    }
}
