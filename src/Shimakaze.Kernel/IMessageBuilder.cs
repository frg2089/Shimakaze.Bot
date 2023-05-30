using Shimakaze.Kernel.Events;
using Shimakaze.Kernel.Messages;
using Shimakaze.Kernel.Messages.Spans;

namespace Shimakaze.Kernel;

public interface IMessageBuilder
{
    IMessageBuilder Add(MessageSpan span);
    IMessageBuilder At(uint uin);
    MessageContent Build();
    IMessageBuilder Image(byte[] data);
    IMessageBuilder Image(string filePath);
    IMessageBuilder Face(int faceId);
    IMessageBuilder Record(string filePath);
    IMessageBuilder Text(string message);
    IMessageBuilder Clear();
}