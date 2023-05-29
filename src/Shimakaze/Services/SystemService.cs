using Konata.Core;
using Konata.Core.Interfaces.Api;
using Konata.Core.Message;

using Microsoft.Extensions.Configuration;

using Shimakaze.System;

namespace Shimakaze.Services;

[Service]
public sealed class SystemService
{
    private readonly Bot _bot;
    private readonly IConfiguration _conf;

    private string MsgPong => _conf["System:Ping:Response"] ?? "Pong!";
    public SystemService(Bot bot, IConfiguration configuration)
    {
        _bot = bot;
        _conf = configuration;
    }

    public void Ping(uint uid)
    {
        _bot.SendFriendMessage(uid, MsgPong);
    }

    public void Ping(uint gid, uint uid)
    {
        _bot.SendGroupMessage(gid, new MessageBuilder().At(uid).Text(MsgPong));
    }
}
