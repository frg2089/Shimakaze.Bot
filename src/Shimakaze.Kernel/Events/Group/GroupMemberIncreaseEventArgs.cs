namespace Shimakaze.Kernel.Events;

public abstract class GroupMemberIncreaseEventArgs : BotEventArgs, IGroupEventArgs, IMemberEventArgs
{
    public uint GroupId { get; protected init; }
    public uint MemberId { get; protected init; }
    public string MemberName { get; protected init; } = string.Empty;
    protected GroupMemberIncreaseEventArgs(object raw) : base(raw)
    {
    }
}
