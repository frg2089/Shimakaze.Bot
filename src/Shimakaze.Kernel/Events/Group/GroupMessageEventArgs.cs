using Shimakaze.Kernel.Messages;

namespace Shimakaze.Kernel.Events;

public abstract class GroupMessageEventArgs : BotEventArgs, IGroupEventArgs, IMemberEventArgs, IMessageEventArgs
{
    public uint GroupId { get; protected init; }
    public uint MemberId { get; protected init; }
    public string GroupName { get; protected init; } = string.Empty;
    public string MemberName { get; protected init; } = string.Empty;
    public Message? Message { get; protected init; }

    protected GroupMessageEventArgs(object raw) : base(raw)
    {
    }
}
