using Shimakaze.Kernel.Messages;

namespace Shimakaze.Kernel.Events;

public interface IMessageEventArgs
{
    Message? Message { get; }
}
