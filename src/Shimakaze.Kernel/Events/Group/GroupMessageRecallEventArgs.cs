namespace Shimakaze.Kernel.Events;

public abstract class GroupMessageRecallEventArgs :BotEventArgs, IGroupEventArgs, IMemberEventArgs, IOperatorEventArgs
{
    public uint GroupId { get; protected init; }
    public uint MemberId { get; protected init; }
    public uint OperatorId { get; protected init; }
    public uint Sequence { get; protected init; }
    public uint Random { get; protected init; }
    protected GroupMessageRecallEventArgs(object raw) : base(raw)
    {
    }
}
