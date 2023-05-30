using Konata.Core.Message.Model;

using Shimakaze.Kernel.Messages;
using Shimakaze.Kernel.Messages.Spans;

namespace Shimakaze.Konata.Messages.Spans;

public sealed record KonataMultiMessageSpan : MultiMessageSpan
{
    internal readonly MultiMsgChain Raw;
    public KonataMultiMessageSpan(MultiMsgChain raw)
    {
        Content = raw.Content;
        Raw = raw;
    }

    public override IEnumerator<MessageContent> GetEnumerator()
        => Raw.Select(i => new KonataMessageContent(i.Chain)).GetEnumerator();
}