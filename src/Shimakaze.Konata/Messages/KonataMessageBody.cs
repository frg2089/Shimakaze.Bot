using Konata.Core.Message;
using Konata.Core.Message.Model;

using Shimakaze.Kernel.Messages;
using Shimakaze.Kernel.Messages.Spans;
using Shimakaze.Konata.Messages.Spans;

namespace Shimakaze.Konata.Messages;

public sealed record KonataMessageContent : MessageContent
{
    internal readonly MessageChain? Raw;
    public KonataMessageContent(IEnumerable<BaseChain> raw)
    {
        _spans.Clear();
        _spans.AddRange(raw.Select(Parse));
    }
    internal KonataMessageContent(MessageChain raw) : this(raw as IEnumerable<BaseChain>)
    {
        Raw = raw;
    }

    private static MessageSpan Parse(BaseChain raw)
    {
        return raw switch
        {
            AtChain at => new KonataAtSpan(at),
            BFaceChain bf => new KonataBFaceSpan(bf),
            FileChain file => new KonataFileSpan(file),
            FlashImageChain fimg => new KonataFlashImageSpan(fimg),
            ImageChain img => new KonataImageSpan(img),
            MultiMsgChain mmc => new KonataMultiMessageSpan(mmc),
            XmlChain xml => new KonataXmlSpan(xml),
            JsonChain json => new KonataJsonSpan(json),
            TextChain text => new KonataTextSpan(text),
            QFaceChain qf => new KonataQFaceSpan(qf),
            RecordChain record => new KonataRecordSpan(record),
            ReplyChain reply => new KonataReplySpan(reply),
            VideoChain video => new KonataVideoSpan(video),
            _ => throw new InvalidCastException(),
        };
    }
}