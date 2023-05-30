namespace Shimakaze.Kernel.Events;

public abstract class FriendTypingEventArgs : BotEventArgs, IFriendEventArgs
{
    public uint FriendId { get; protected init; }
    protected FriendTypingEventArgs(object raw) : base(raw)
    {
    }
}
