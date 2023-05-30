namespace Shimakaze.Kernel.Events;

public abstract class GroupPromoteAdminEventArgs : BotEventArgs, IGroupEventArgs, IMemberEventArgs
{
    public uint GroupId { get; protected init; }
    public uint MemberId { get; protected init; }
    public bool ToggleType { get; protected init; }
    protected GroupPromoteAdminEventArgs(object raw) : base(raw)
    {
    }
}
