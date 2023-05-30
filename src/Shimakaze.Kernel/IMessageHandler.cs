using Shimakaze.Kernel.Events;

namespace Shimakaze.Kernel;

public interface IMessageHandler
{
    int Weight { get; }
}

public interface IMessageHandler<in TBotEventArgs> : IMessageHandler
    where TBotEventArgs : BotEventArgs
{
    bool CanExecute(TBotEventArgs args);
    Task ExecuteAsync(TBotEventArgs args, CancellationToken cancellationToken = default);
}
