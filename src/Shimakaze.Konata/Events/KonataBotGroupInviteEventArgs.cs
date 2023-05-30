using Konata.Core.Events.Model;

using Shimakaze.Kernel.Events;

namespace Shimakaze.Konata.Events;

public sealed class KonataBotGroupInviteEventArgs : GroupInviteEventArgs
{
    public KonataBotGroupInviteEventArgs(GroupInviteEvent raw) : base(raw)
    {
        Time = raw.EventTime;
        Description = raw.EventMessage;
        GroupId = raw.GroupUin;
        GroupName = raw.GroupName;
        InviterId = raw.InviterUin;
        InviterName = raw.InviterNick;
        InviterIsAdmin = raw.InviterIsAdmin;
        InviteTime = raw.InviteTime;
        Token = raw.Token;
    }
}