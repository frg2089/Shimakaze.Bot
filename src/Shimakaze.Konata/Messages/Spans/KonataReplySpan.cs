using Konata.Core.Message.Model;

using Shimakaze.Kernel.Messages.Spans;

namespace Shimakaze.Konata.Messages.Spans;

public sealed record KonataReplySpan : ReplySpan
{
    internal readonly ReplyChain Raw;
    public KonataReplySpan(ReplyChain raw)
    {
        Raw = raw;
        Id = raw.Uin;
        Sequence = raw.Sequence;
        Uuid = raw.Uuid;
        Time = raw.Time;
        Preview = raw.Preview;
    }
}