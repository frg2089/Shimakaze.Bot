namespace Shimakaze.Kernel.Events;

public abstract class GroupRequestJoinEventArgs : BotEventArgs, IGroupEventArgs, IRequestEventArgs
{
    public uint GroupId { get; protected init; }
    public string GroupName { get; protected init; } = string.Empty;
    public uint InviterId { get; protected init; }
    public uint ReqId { get; protected init; }
    public string ReqName { get; protected init; } = string.Empty;
    public uint ReqTime { get; protected init; }
    public string ReqComment { get; protected init; } = string.Empty;
    public long Token { get; protected init; }
    protected GroupRequestJoinEventArgs(object raw) : base(raw)
    {
    }
}
