using Konata.Core.Common;

namespace Shimakaze.System.Hack;

internal sealed class BotConfig : Konata.Core.Common.BotConfig
{
    public new OicqProtocol Protocol
    {
        get => base.Protocol;
        set => base.Protocol = value;
    }
}