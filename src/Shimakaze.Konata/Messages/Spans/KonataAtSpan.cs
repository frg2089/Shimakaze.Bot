using Konata.Core.Message.Model;

using Shimakaze.Kernel.Messages.Spans;

namespace Shimakaze.Konata.Messages.Spans;

public sealed record KonataAtSpan : AtSpan
{
    internal readonly AtChain Raw;
    public KonataAtSpan(AtChain raw)
    {
        Raw = raw;
        Id = raw.AtUin;
    }
}