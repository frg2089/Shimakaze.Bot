using Microsoft.Extensions.Configuration;

using Shimakaze.Kernel;
using Shimakaze.Kernel.Events;

namespace Shimakaze.Services;

public sealed class Ping : IMessageHandler<FriendMessageEventArgs>, IMessageHandler<GroupMessageEventArgs>
{
    private readonly IBot _bot;
    private readonly IMessageBuilder _builder;
    public bool NeedAt { get; set; }
    public string Request { get; set; } = string.Empty;
    public string Response { get; set; } = string.Empty;

    public int Weight { get; } = 0;

    public Ping(IBot bot, IConfiguration configuration, IMessageBuilder builder)
    {
        _bot = bot;
        configuration.GetSection("System:Ping").Bind(this);
        _builder = builder;
    }

    public bool CanExecute(FriendMessageEventArgs args)
    {
        return args.GetSpans()?.Has(Request) ?? false;
    }

    public bool CanExecute(GroupMessageEventArgs args)
    {
        if (NeedAt)
        {
            if (!args.IsAtMe(_bot))
                return false;
        }

        return args.GetSpans()?.Has(Request) ?? false;
    }

    public async Task ExecuteAsync(FriendMessageEventArgs args, CancellationToken cancellationToken = default)
    {
        await _bot.SendFriendAsync(args.FriendId, _builder.Clear().Text(Response));
    }

    public async Task ExecuteAsync(GroupMessageEventArgs args, CancellationToken cancellationToken = default)
    {
        await _bot.SendGroupAsync(args.GroupId, _builder.Clear().At(args.MemberId).Text(Response));
    }
}