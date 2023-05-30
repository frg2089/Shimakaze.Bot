using Konata.Core;
using Konata.Core.Interfaces.Api;

using Shimakaze.Kernel;
using Shimakaze.Kernel.Events;
using Shimakaze.Konata.Events;

namespace Shimakaze.Konata;

public sealed class KonataBot : IBot, IDisposable
{
    internal readonly Bot Bot;

    public uint Id => Bot.Uin;

    public event BotEventHandler<BotEventArgs>? Event;

    public KonataBot(Bot bot)
    {
        Bot = bot;
        Bot.OnLog += (_, e) => Event?.Invoke(this, new KonataBotLogEventArgs(e));
        Bot.OnBotOnline += (_, e) => Event?.Invoke(this, new KonataBotBotOnlineEventArgs(e));
        Bot.OnBotOffline += (_, e) => Event?.Invoke(this, new KonataBotBotOfflineEventArgs(e));
        Bot.OnCaptcha += (_, e) => Event?.Invoke(this, new KonataBotCaptchaEventArgs(e));
        Bot.OnGroupMessage += (_, e) => Event?.Invoke(this, new KonataBotGroupMessageEventArgs(e));
        Bot.OnGroupMute += (_, e) => Event?.Invoke(this, new KonataBotGroupMuteEventArgs(e));
        Bot.OnGroupMessageRecall += (_, e) => Event?.Invoke(this, new KonataBotGroupMessageRecallEventArgs(e));
        Bot.OnGroupPoke += (_, e) => Event?.Invoke(this, new KonataBotGroupPokeEventArgs(e));
        Bot.OnGroupMemberDecrease += (_, e) => Event?.Invoke(this, new KonataBotGroupMemberDecreaseEventArgs(e));
        Bot.OnGroupMemberIncrease += (_, e) => Event?.Invoke(this, new KonataBotGroupMemberIncreaseEventArgs(e));
        Bot.OnGroupPromoteAdmin += (_, e) => Event?.Invoke(this, new KonataBotGroupPromoteAdminEventArgs(e));
        Bot.OnGroupInvite += (_, e) => Event?.Invoke(this, new KonataBotGroupInviteEventArgs(e));
        Bot.OnGroupRequestJoin += (_, e) => Event?.Invoke(this, new KonataBotGroupRequestJoinEventArgs(e));
        Bot.OnFriendMessage += (_, e) => Event?.Invoke(this, new KonataBotFriendMessageEventArgs(e));
        Bot.OnFriendMessageRecall += (_, e) => Event?.Invoke(this, new KonataBotFriendMessageRecallEventArgs(e));
        Bot.OnFriendPoke += (_, e) => Event?.Invoke(this, new KonataBotFriendPokeEventArgs(e));
        Bot.OnFriendTyping += (_, e) => Event?.Invoke(this, new KonataBotFriendTypingEventArgs(e));
        Bot.OnFriendRequest += (_, e) => Event?.Invoke(this, new KonataBotFriendRequestEventArgs(e));
    }

    public void Dispose() => Bot.Dispose();

    public Task SendFriendAsync(uint id, IMessageBuilder message)
    {
        Bot.SendFriendMessage(id, (message as KonataMessageBuilder)?.Builder);
        return Task.CompletedTask;
    }

    public Task SendGroupAsync(uint id, IMessageBuilder message)
    {
        Bot.SendGroupMessage(id, (message as KonataMessageBuilder)?.Builder);
        return Task.CompletedTask;
    }

    public async Task<bool> LoginAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return await Bot.Login();
    }

    public async Task<bool> LogoutAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return await Bot.Logout();
    }
}