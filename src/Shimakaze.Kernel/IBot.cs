using Shimakaze.Kernel.Events;

namespace Shimakaze.Kernel;

public interface IBot
{
    uint Id { get; }
    event BotEventHandler<BotEventArgs>? Event;

    Task SendFriendAsync(uint id, IMessageBuilder message);
    Task SendGroupAsync(uint id, IMessageBuilder message);

    Task<bool> LoginAsync(CancellationToken cancellationToken = default);
    Task<bool> LogoutAsync(CancellationToken cancellationToken = default);
}
