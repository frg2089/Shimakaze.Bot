namespace Shimakaze.Kernel.Events;

public abstract class GroupMuteEventArgs :BotEventArgs, IGroupEventArgs, IMemberEventArgs, IOperatorEventArgs
{
    public uint GroupId { get; protected init; }
    public uint MemberId { get; protected init; }
    public uint OperatorId { get; protected init; }
    public uint Seconds { get; protected init; }
    protected GroupMuteEventArgs(object raw) : base(raw)
    {
    }
}
