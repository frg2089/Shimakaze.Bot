using Konata.Core.Events.Model;

using Shimakaze.Kernel.Events;

namespace Shimakaze.Konata.Events;

public sealed class KonataBotGroupMemberDecreaseEventArgs : GroupMemberDecreaseEventArgs
{
    public KonataBotGroupMemberDecreaseEventArgs(GroupKickMemberEvent raw) : base(raw)
    {
        Time = raw.EventTime;
        Description = raw.EventMessage;
        GroupId = raw.GroupUin;
        MemberId = raw.MemberUin;
        OperatorId = raw.OperatorUin;
        ToggleType = raw.ToggleType;
    }
}