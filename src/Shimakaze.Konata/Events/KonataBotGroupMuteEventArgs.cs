using Konata.Core.Events.Model;

using Shimakaze.Kernel.Events;

namespace Shimakaze.Konata.Events;

public sealed class KonataBotGroupMuteEventArgs : GroupMuteEventArgs
{
    public KonataBotGroupMuteEventArgs(GroupMuteMemberEvent raw) : base(raw)
    {
        Time = raw.EventTime;
        Description = raw.EventMessage;
        GroupId = raw.GroupUin;
        MemberId = raw.MemberUin;
        OperatorId = raw.OperatorUin;
        Seconds = raw.TimeSeconds;
    }
}