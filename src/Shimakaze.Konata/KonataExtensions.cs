using Konata.Core.Common;
using Konata.Core.Interfaces;

using Microsoft.Extensions.DependencyInjection;

using Shimakaze.Kernel;

namespace Shimakaze.Konata;

public static class KonataExtensions
{
    public static IServiceCollection AddKonataHostedService(
        this IServiceCollection services,
        Action<BotConfig> botConfig,
        Action<BotDevice> botDevice,
        BotKeyStore keyStore)
    {
        BotConfig config = new BotConfigHack();
        BotDevice device = new();
        botConfig(config);
        botDevice(device);
        return services
            .AddSingleton<IBot>(provider => new KonataBot(BotFather.Create(config, device, keyStore)))
            .AddTransient<IMessageBuilder, KonataMessageBuilder>()
            .AddHostedService<KonataBotHostedService>();
    }
}