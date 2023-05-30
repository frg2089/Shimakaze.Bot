using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;

using Konata.Core.Interfaces.Api;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Shimakaze.Kernel;
using Shimakaze.Kernel.Events;

namespace Shimakaze.Konata;

public sealed class KonataBotHostedService : IHostedService
{
    private readonly IBot _bot;
    private readonly ILogger<KonataBotHostedService> _logger;
    private readonly IServiceProvider _provider;
    private readonly CancellationTokenSource _cancellationTokenSource = new();

    public KonataBotHostedService(IBot bot, ILogger<KonataBotHostedService> logger, IServiceProvider provider)
    {
        _bot = bot;
        _logger = logger;
        _provider = provider;
        _bot.Event += OnEvent;
    }

    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    private readonly Dictionary<Type, (MethodInfo CanExecute, MethodInfo ExecuteAsync)> _reflectionCache = new();

    private async void OnEvent(IBot sender, BotEventArgs args)
    {
        switch (args)
        {
            case LogEventArgs log:
                _logger.Log(log.Level, "[{time}]\t[{category}]\t{message}", log.Time, log.Category, log.Description);
                break;
            case CaptchaEventArgs captcha when sender is KonataBot bot:
                _logger.LogInformation("[{time}]\t{message}", args.Time, args.Description);
                if (captcha.IsSlider)
                {
                    _logger.LogInformation("[{time}]Slider Captcha:\t{url}", captcha.SliderUrl);
                    Console.Write("Please Type Ticket: ");
                    bot.Bot.SubmitSliderTicket(Console.ReadLine());

                }
                else if (captcha.IsSMS)
                {
                    _logger.LogInformation("Captcha: Please type your SMS code. Phone: {phone}", captcha.Phone);
                    Console.Write("Please Type SMS Code: ");
                    bot.Bot.SubmitSmsCode(Console.ReadLine());
                }
                break;
            case GroupMessageEventArgs group:
                _logger.LogInformation("[{time}]\t[{group}({gid}) - {member}({uid})]:\t{message}", args.Time, group.GroupName, group.GroupId, group.MemberName, group.MemberId, group.Message);
                break;
            case FriendMessageEventArgs friend:
                _logger.LogInformation("[{time}]\t[{member}({uid})]:\t{message}", args.Time, friend.FriendName, friend.FriendId, friend.Message);
                break;
            default:
                _logger.LogInformation("[{time}]\t{message}", args.Time, args.Description);
                _logger.LogTrace("Details: {args}", JsonSerializer.Serialize(args, JsonSerializerOptions));
                break;
        }
        if (args.GetType().BaseType is not Type type)
            return;

        type = typeof(IMessageHandler<>).MakeGenericType(type);
        try
        {
            await using var scope = _provider.CreateAsyncScope();
            var provider = scope.ServiceProvider;

            if (!_reflectionCache.TryGetValue(type, out (MethodInfo CanExecute, MethodInfo ExecuteAsync) handler))
            {
                handler = _reflectionCache[type] = (
                    type.GetMethod(nameof(IMessageHandler<BotEventArgs>.CanExecute))!,
                    type.GetMethod(nameof(IMessageHandler<BotEventArgs>.ExecuteAsync))!
                );
            }

            object? target = provider.GetServices(type)
                .Cast<IMessageHandler>()
                .OrderByDescending(i => i.Weight)
                .FirstOrDefault(i => (bool)handler.CanExecute.Invoke(i, new[] { args })!);
            if (target is null)
                return;

            await (Task)handler.ExecuteAsync.Invoke(target, new object[] { args, _cancellationTokenSource.Token })!;
        }
        catch (Exception ex)
        {
            _logger.LogError(new EventId(-1, "Unhandler Exception"), ex, "Unhandler Exception");
        }
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        try
        {
            for (int retry = 1; !await _bot.LoginAsync(cancellationToken); retry++)
            {
                var ms = 5000 * retry;
                _logger.LogError("Login failed, retry after {s}s", ms / 1000);
                await Task.Delay(ms, cancellationToken);
            }
        }
        catch (OperationCanceledException)
        {
        }
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        _cancellationTokenSource.Cancel();
        await _bot.LogoutAsync(cancellationToken);
    }
}