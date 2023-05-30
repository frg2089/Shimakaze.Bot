
using System.Reflection;

using Konata.Core.Common;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Shimakaze.Kernel;
using Shimakaze.Konata;

using Tomlyn.Extensions.Configuration;

await Host
    .CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, config) => config
        .AddTomlFile("appsettings.toml", optional: true, reloadOnChange: true)
        .AddTomlFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.toml", optional: true, reloadOnChange: true)
    )
    .ConfigureServices((context, config) =>
    {
        string[]? exts = context.Configuration.GetSection("System:Extensions").Get<string[]>();
        if (exts is not null)
        {
            foreach (var ext in exts)
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ext + ".dll");
                if (!File.Exists(path))
                    path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Extensions", ext + ".dll");
                if (!File.Exists(path))
                    continue;

                Console.WriteLine("Load Extension: {0}", path);
                Assembly.LoadFile(path);
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No Extensions");
            Console.ResetColor();
        }
        Console.Write("Please Type your password in here: ");
        var password = Console.ReadLine();
        Console.CursorTop--;
        Console.WriteLine(new string(' ', Console.WindowWidth));
        Console.CursorTop--;
        config
            .AddKonataHostedService(
                config => context.Configuration.GetSection("BotConfig").Bind(config),
                device => context.Configuration.GetSection("BotDevice").Bind(device),
                new BotKeyStore(context.Configuration["Account"], password)
            )
            .AddHandler();
    })
    .RunConsoleAsync();