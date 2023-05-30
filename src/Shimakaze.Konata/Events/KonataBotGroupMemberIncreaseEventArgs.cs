using Konata.Core.Events.Model;

using Shimakaze.Kernel.Events;

namespace Shimakaze.Konata.Events;

public sealed class KonataBotGroupMemberIncreaseEventArgs : GroupMemberIncreaseEventArgs
{
    public KonataBotGroupMemberIncreaseEventArgs(GroupMemberIncreaseEvent raw) : base(raw)
    {
        Time = raw.EventTime;
        Description = raw.EventMessage;
        GroupId = raw.GroupUin;
        MemberId = raw.MemberUin;
        MemberName = raw.MemberNick;
    }
}