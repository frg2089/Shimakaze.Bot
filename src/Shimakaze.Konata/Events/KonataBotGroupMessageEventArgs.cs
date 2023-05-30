using Konata.Core.Events.Model;

using Shimakaze.Kernel.Events;
using Shimakaze.Konata.Messages;

namespace Shimakaze.Konata.Events;

public sealed class KonataBotGroupMessageEventArgs : GroupMessageEventArgs
{
    public KonataBotGroupMessageEventArgs(GroupMessageEvent raw) : base(raw)
    {
        Time = raw.EventTime;
        Description = raw.EventMessage;
        GroupId = raw.GroupUin;
        GroupName = raw.GroupName;
        MemberId = raw.MemberUin;
        MemberName = raw.MemberCard;
        Message = new KonataMessage(raw.Message);
    }
}