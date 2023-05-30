using Konata.Core.Events.Model;

using Shimakaze.Kernel.Events;

namespace Shimakaze.Konata.Events;

public sealed class KonataBotFriendTypingEventArgs : FriendTypingEventArgs
{
    public KonataBotFriendTypingEventArgs(FriendTypingEvent raw) : base(raw)
    {
        Time = raw.EventTime;
        Description = raw.EventMessage;
        FriendId = raw.FriendUin;
    }
}