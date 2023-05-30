using Konata.Core.Message.Model;

using Shimakaze.Kernel.Messages.Spans;

namespace Shimakaze.Konata.Messages.Spans;

public sealed record KonataXmlSpan : XmlSpan
{
    internal readonly XmlChain Raw;
    public KonataXmlSpan(XmlChain raw)
    {
        Raw = raw;
        Content = raw.Content;
    }
}