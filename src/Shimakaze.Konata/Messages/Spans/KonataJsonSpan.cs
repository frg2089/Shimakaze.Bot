using Konata.Core.Message.Model;

using Shimakaze.Kernel.Messages.Spans;

namespace Shimakaze.Konata.Messages.Spans;

public sealed record KonataJsonSpan : JsonSpan
{
    internal readonly JsonChain Raw;
    public KonataJsonSpan(JsonChain raw)
    {
        Raw = raw;
        Content = raw.Content;
    }
}