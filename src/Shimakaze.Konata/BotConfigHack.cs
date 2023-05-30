using Konata.Core.Common;

namespace Shimakaze.Konata;

public sealed class BotConfigHack : BotConfig
{
    public new OicqProtocol Protocol
    {
        get => base.Protocol;
        set => base.Protocol = value;
    }
}