using Konata.Core.Message;
using Konata.Core.Message.Model;

using Shimakaze.Kernel;
using Shimakaze.Kernel.Messages;
using Shimakaze.Kernel.Messages.Spans;
using Shimakaze.Konata.Messages;
using Shimakaze.Konata.Messages.Spans;

namespace Shimakaze.Konata;

public sealed class KonataMessageBuilder : IMessageBuilder
{
    internal MessageBuilder Builder { get; private set; } = new();

    public IMessageBuilder Add(MessageSpan span)
    {
        Builder.Add(span switch
        {
            KonataAtSpan at => at.Raw,
            KonataBFaceSpan bFace => bFace.Raw,
            KonataFileSpan file => file.Raw,
            KonataFlashImageSpan flashImage => flashImage.Raw,
            KonataImageSpan image => image.Raw,
            KonataJsonSpan json => json.Raw,
            KonataMultiMessageSpan multiMessage => multiMessage.Raw,
            KonataQFaceSpan qFace => qFace.Raw,
            KonataRecordSpan record => record.Raw,
            KonataReplySpan reply => reply.Raw,
            KonataTextSpan text => text.Raw,
            KonataVideoSpan video => video.Raw,
            KonataXmlSpan xml => xml.Raw,
            _ => TextChain.Create(span.ToString())
        });

        return this;
    }

    public MessageContent Build() => new KonataMessageContent(Builder.Build());

    public IMessageBuilder Text(string message)
    {
        Builder.Text(message);
        return this;
    }

    public IMessageBuilder At(uint uin)
    {
        Builder.At(uin);
        return this;
    }

    public IMessageBuilder Face(int faceId)
    {
        Builder.QFace(faceId);
        return this;
    }

    public IMessageBuilder Image(byte[] data)
    {
        Builder.Image(data);
        return this;
    }

    public IMessageBuilder Image(string filePath)
    {
        Builder.Image(filePath);
        return this;
    }

    public IMessageBuilder Record(string filePath)
    {
        Builder.Record(filePath);
        return this;
    }

    public IMessageBuilder Clear()
    {
        Builder = new();
        return this;
    }
}