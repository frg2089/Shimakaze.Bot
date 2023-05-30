namespace Shimakaze.Kernel.Events;

public abstract class FriendMessageRecallEventArgs : BotEventArgs, IFriendEventArgs, IOperatorEventArgs
{
    public uint FriendId { get; protected init; }
    public uint OperatorId { get; protected init; }
    public uint Sequence { get; protected init; }
    public long Uuid { get; protected init; }
    protected FriendMessageRecallEventArgs(object raw) : base(raw)
    {
    }
}
