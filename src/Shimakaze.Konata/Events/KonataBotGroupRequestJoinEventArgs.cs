using Konata.Core.Events.Model;

using Shimakaze.Kernel.Events;

namespace Shimakaze.Konata.Events;

public sealed class KonataBotGroupRequestJoinEventArgs : GroupRequestJoinEventArgs
{
    public KonataBotGroupRequestJoinEventArgs(GroupRequestJoinEvent raw) : base(raw)
    {
        Time = raw.EventTime;
        Description = raw.EventMessage;
        GroupId = raw.GroupUin;
        GroupName = raw.GroupName;
        InviterId = raw.InviterUin;
        ReqId = raw.ReqUin;
        ReqName = raw.ReqNick;
        ReqTime = raw.ReqTime;
        ReqComment = raw.ReqComment;
        Token = raw.Token;
    }
}