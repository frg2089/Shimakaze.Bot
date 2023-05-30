using Shimakaze.Kernel.Messages;

namespace Shimakaze.Kernel.Events;

public abstract class FriendMessageEventArgs : BotEventArgs, IFriendEventArgs, IMessageEventArgs
{
    public uint FriendId { get; protected init; }
    public string FriendName { get; protected init; } = string.Empty;
    public Message? Message { get; protected init; }
    protected FriendMessageEventArgs(object raw) : base(raw)
    {
    }
}
