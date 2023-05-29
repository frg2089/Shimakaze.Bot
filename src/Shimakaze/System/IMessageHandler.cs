using Konata.Core.Events;

namespace Shimakaze.System;

public interface IMessageHandler
{
}

public interface IMessageHandler<TEvent> where TEvent : BaseEvent
{
    bool CanExecute(TEvent args);
    Task ExecuteAsync(TEvent args, CancellationToken cancellationToken = default);
}
