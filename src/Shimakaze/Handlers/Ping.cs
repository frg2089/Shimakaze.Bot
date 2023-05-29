using Konata.Core.Events.Model;

using Microsoft.Extensions.Configuration;

using Shimakaze.Services;
using Shimakaze.System;

namespace Shimakaze.Handlers;

public sealed class Ping : IMessageHandler<FriendMessageEvent>, IMessageHandler<GroupMessageEvent>
{
    private readonly SystemService _system;
    private readonly MessageService _condition;
    private readonly IConfiguration _conf;
    private string MsgRequest => _conf["System:Ping:Request"] ?? "ping";

    public Ping(SystemService system, MessageService parser, IConfiguration configuration)
    {
        _system = system;
        _condition = parser;
        _conf = configuration;
    }

    public bool CanExecute(FriendMessageEvent args)
    {
        return _condition.Condition(args.Chain).Contains(MsgRequest).Invoke();
    }

    public bool CanExecute(GroupMessageEvent args)
    {
        return _condition.Condition(args.Chain).AtMe().Contains(MsgRequest).Invoke();
    }

    public Task ExecuteAsync(FriendMessageEvent args, CancellationToken cancellationToken = default)
    {
        _system.Ping(args.FriendUin);
        return Task.CompletedTask;
    }

    public Task ExecuteAsync(GroupMessageEvent args, CancellationToken cancellationToken = default)
    {
        _system.Ping(args.GroupUin, args.MemberUin);
        return Task.CompletedTask;
    }
}