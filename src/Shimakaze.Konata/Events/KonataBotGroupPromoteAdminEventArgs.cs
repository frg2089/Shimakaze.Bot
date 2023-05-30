using Konata.Core.Events.Model;

using Shimakaze.Kernel.Events;

namespace Shimakaze.Konata.Events;

public sealed class KonataBotGroupPromoteAdminEventArgs : GroupPromoteAdminEventArgs
{
    public KonataBotGroupPromoteAdminEventArgs(GroupPromoteAdminEvent raw) : base(raw)
    {
        Time = raw.EventTime;
        Description = raw.EventMessage;
        GroupId = raw.GroupUin;
        MemberId = raw.MemberUin;
        ToggleType = raw.ToggleType;
    }
}