using Konata.Core.Events.Model;

using Shimakaze.Kernel.Events;
using Shimakaze.Konata.Messages;

namespace Shimakaze.Konata.Events;

public sealed class KonataBotFriendMessageEventArgs : FriendMessageEventArgs
{
    public KonataBotFriendMessageEventArgs(FriendMessageEvent raw) : base(raw)
    {
        Time = raw.EventTime;
        Description = raw.EventMessage;
        FriendId = raw.FriendUin;
        FriendName = (raw.Message.Receiver.Uin == raw.SelfUin) ? raw.Message.Sender.Name : raw.Message.Receiver.Name;
        Message = new KonataMessage(raw.Message);
    }
}