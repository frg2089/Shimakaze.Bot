using Konata.Core.Common;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Shimakaze;
using Shimakaze.System;

using Tomlyn.Extensions.Configuration;

await Host
    .CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, config) => config
        .AddTomlFile("appsettings.toml", optional: true, reloadOnChange: true)
        .AddTomlFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.toml", optional: true, reloadOnChange: true)
    )
    .ConfigureServices((context, config) => config
        .AddHostedService<BotService>(services => new(
            services.GetRequiredService<BotConfig>(),
            services.GetRequiredService<BotDevice>(),
            services.GetRequiredService<BotKeyStore>(),
            services.GetRequiredService<ILogger<BotService>>(),
            config
        ))
        .AddSingleton<BotConfig>(context.Configuration.Bind<Shimakaze.System.Hack.BotConfig>(nameof(BotConfig)))
        .AddSingleton(context.Configuration.Bind<BotDevice>(nameof(BotDevice)))
        .AddSingleton(new BotKeyStore(context.Configuration["Account"], context.Configuration["Password"]))
        .AddServices()
        .AddHandler()
    )
    .RunConsoleAsync();