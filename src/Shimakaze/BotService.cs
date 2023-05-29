using Konata.Core;
using Konata.Core.Common;
using Konata.Core.Events;
using Konata.Core.Events.Model;
using Konata.Core.Interfaces;
using Konata.Core.Interfaces.Api;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Shimakaze.System;

namespace Shimakaze;

public sealed class BotService : IHostedService, IDisposable
{
    private Bot? _bot;
    private readonly BotConfig _config;
    private readonly BotDevice _device;
    private readonly BotKeyStore _keyStore;
    private readonly ILogger<BotService> _logger;
    private readonly IServiceCollection _services;

    public BotService(BotConfig config, BotDevice device, BotKeyStore keyStore, ILogger<BotService> logger, IServiceCollection services)
    {
        _config = config;
        _device = device;
        _keyStore = keyStore;
        _logger = logger;
        _services = services;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _bot = BotFather.Create(_config, _device, _keyStore);
        _bot.OnCaptcha += OnCaptcha;
        _bot.OnLog += OnLog;
        _bot.OnGroupMessage += OnGroupMessage;
        _bot.OnFriendMessage += OnFriendMessage;
        _bot.OnBotOnline += OnBotOnline;
        if (!await _bot.Login())
        {
            _logger.LogCritical("Login failed");
            Environment.Exit(-1);
        }
        _services.AddSingleton(_bot);
    }

    private void OnBotOnline(Bot sender, BotOnlineEvent args)
    {
        _logger.LogInformation("Shimakaze now online!");
    }

    private async void OnFriendMessage(Bot sender, FriendMessageEvent args)
    {
        _logger.LogInformation("[Friend]\t{user}({uid}): {msg}", args.Message.Sender.Name, args.Message.Sender.Uin, args.Chain);
        await using var provider = _services.BuildServiceProvider();
        await (provider.GetServices<IMessageHandler<FriendMessageEvent>>().FirstOrDefault(i => i.CanExecute(args))?.ExecuteAsync(args) ?? Task.CompletedTask);
    }

    private async void OnGroupMessage(Bot sender, GroupMessageEvent args)
    {
        _logger.LogInformation("[Group]\t[{group}({gid})]{user}({uid}): {msg}", args.GroupName, args.GroupUin, args.MemberCard, args.MemberUin, args.Chain);
        await using var provider = _services.BuildServiceProvider();
        await (provider.GetServices<IMessageHandler<GroupMessageEvent>>().FirstOrDefault(i => i.CanExecute(args))?.ExecuteAsync(args) ?? Task.CompletedTask);
    }

    private void OnLog(Bot sender, LogEvent args)
    {
        switch (args.Level)
        {
            case Konata.Core.Events.LogLevel.Verbose:
                _logger.LogDebug("{meg}", args.EventMessage);
                break;
            case Konata.Core.Events.LogLevel.Information:
                _logger.LogInformation("{meg}", args.EventMessage);
                break;
            case Konata.Core.Events.LogLevel.Warning:
                _logger.LogWarning("{meg}", args.EventMessage);
                break;
            case Konata.Core.Events.LogLevel.Exception:
                _logger.LogError("{meg}", args.EventMessage);
                break;
            case Konata.Core.Events.LogLevel.Fatal:
                _logger.LogCritical("{meg}", args.EventMessage);
                break;
            default:
                break;
        }
    }

    private void OnCaptcha(Bot sender, CaptchaEvent args)
    {
        switch (args.Type)
        {
            case CaptchaEvent.CaptchaType.Slider:
                _logger.LogInformation("Captcha: {url}", args.SliderUrl);
                sender.SubmitSliderTicket(Console.ReadLine());
                break;
            case CaptchaEvent.CaptchaType.Sms:
                _logger.LogInformation("Captcha: Please type your SMS code. Phone: {phone}", args.Phone);
                sender.SubmitSmsCode(Console.ReadLine());
                break;
            default:
                _logger.LogCritical("Unknown {obj}", args);
                Environment.Exit(-1);
                break;
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _bot?.Logout();
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _bot?.Dispose();
    }
}