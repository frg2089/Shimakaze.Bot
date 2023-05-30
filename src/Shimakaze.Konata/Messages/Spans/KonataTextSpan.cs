using Konata.Core.Message.Model;

using Shimakaze.Kernel.Messages.Spans;

namespace Shimakaze.Konata.Messages.Spans;

public sealed record KonataTextSpan : TextSpan
{
    internal readonly TextChain Raw;
    public KonataTextSpan(TextChain raw)
    {
        Raw = raw;
        Content = raw.Content;
    }
}