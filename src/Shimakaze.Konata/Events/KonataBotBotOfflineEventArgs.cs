using Konata.Core.Events.Model;

using Shimakaze.Kernel.Events;

namespace Shimakaze.Konata.Events;

public sealed class KonataBotBotOfflineEventArgs : BotOfflineEventArgs
{
    internal readonly BotOfflineEvent Raw;

    public KonataBotBotOfflineEventArgs(BotOfflineEvent raw) : base(raw)
    {
        Raw = raw;
        Time = raw.EventTime;
        Description = raw.EventMessage;
        Type = (OfflineType)raw.Type;
    }
}