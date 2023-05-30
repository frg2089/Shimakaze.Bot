using Konata.Core.Events.Model;

using Shimakaze.Kernel.Events;

namespace Shimakaze.Konata.Events;

public sealed class KonataBotFriendMessageRecallEventArgs : FriendMessageRecallEventArgs
{
    public KonataBotFriendMessageRecallEventArgs(FriendMessageRecallEvent raw) : base(raw)
    {
        Time = raw.EventTime;
        Description = raw.EventMessage;
        FriendId = raw.FriendUin;
        OperatorId = raw.OperatorUin;
        Sequence = raw.Sequence;
        Uuid = raw.Uuid;
    }
}