using Konata.Core.Events.Model;

using Shimakaze.Kernel.Events;

namespace Shimakaze.Konata.Events;

public sealed class KonataBotFriendPokeEventArgs : FriendPokeEventArgs
{
    public KonataBotFriendPokeEventArgs(FriendPokeEvent raw) : base(raw)
    {
        Time = raw.EventTime;
        Description = raw.EventMessage;
        FriendId = raw.FriendUin;
        Prefix = raw.ActionPrefix;
        Suffix = raw.ActionSuffix;
    }
}