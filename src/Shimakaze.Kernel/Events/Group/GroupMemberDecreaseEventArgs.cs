namespace Shimakaze.Kernel.Events;

public abstract class GroupMemberDecreaseEventArgs : BotEventArgs, IGroupEventArgs, IMemberEventArgs, IOperatorEventArgs
{
    public uint GroupId { get; protected init; }
    public uint MemberId { get; protected init; }
    public uint OperatorId { get; protected init; }
    public bool ToggleType { get; protected init; }
    protected GroupMemberDecreaseEventArgs(object raw) : base(raw)
    {
    }
}
