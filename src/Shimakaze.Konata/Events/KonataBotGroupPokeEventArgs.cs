using Konata.Core.Events.Model;

using Shimakaze.Kernel.Events;

namespace Shimakaze.Konata.Events;

public sealed class KonataBotGroupPokeEventArgs : GroupPokeEventArgs
{
    public KonataBotGroupPokeEventArgs(GroupPokeEvent raw) : base(raw)
    {
        Time = raw.EventTime;
        Description = raw.EventMessage;
        GroupId = raw.GroupUin;
        MemberId = raw.MemberUin;
        OperatorId = raw.OperatorUin;
        Prefix = raw.ActionPrefix;
        Suffix = raw.ActionSuffix;
    }
}