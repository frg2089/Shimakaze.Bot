using Konata.Core.Events.Model;

using Shimakaze.Kernel.Events;

namespace Shimakaze.Konata.Events;

public sealed class KonataBotBotOnlineEventArgs : BotOnlineEventArgs
{
    public KonataBotBotOnlineEventArgs(BotOnlineEvent raw) : base(raw)
    {
        Time = raw.EventTime;
        Description = raw.EventMessage;
        Type = (OnlineType)raw.Type;
    }
}