using Konata.Core.Events.Model;

using Shimakaze.Kernel.Events;

namespace Shimakaze.Konata.Events;

public sealed class KonataBotFriendRequestEventArgs : FriendRequestEventArgs
{
    public KonataBotFriendRequestEventArgs(FriendRequestEvent raw) : base(raw)
    {
        Time = raw.EventTime;
        Description = raw.EventMessage;
        ReqId = raw.ReqUin;
        ReqName = raw.ReqNick;
        ReqTime = raw.ReqTime;
        ReqComment = raw.ReqComment;
        Token = raw.Token;
    }
}