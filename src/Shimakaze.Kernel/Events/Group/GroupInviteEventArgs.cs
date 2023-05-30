namespace Shimakaze.Kernel.Events;

public abstract class GroupInviteEventArgs : BotEventArgs
{
    public uint GroupId { get; protected init; }
    public string GroupName { get; protected init; } = string.Empty;
    public uint InviterId { get; protected init; }
    public string InviterName { get; protected init; } = string.Empty;
    public bool InviterIsAdmin { get; protected init; }
    public uint InviteTime { get; protected init; }
    public long Token { get; protected init; }
    protected GroupInviteEventArgs(object raw) : base(raw)
    {
    }
}
