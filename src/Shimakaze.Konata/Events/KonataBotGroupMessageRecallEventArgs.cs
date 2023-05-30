using Konata.Core.Events.Model;

using Shimakaze.Kernel.Events;

namespace Shimakaze.Konata.Events;

public sealed class KonataBotGroupMessageRecallEventArgs : GroupMessageRecallEventArgs
{
    public KonataBotGroupMessageRecallEventArgs(GroupMessageRecallEvent raw) : base(raw)
    {
        Time = raw.EventTime;
        Description = raw.EventMessage;
        GroupId = raw.GroupUin;
        MemberId = raw.AffectedUin;
        OperatorId = raw.OperatorUin;
        Sequence = raw.Sequence;
        Random = raw.Random;
    }
}