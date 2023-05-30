using Konata.Core.Message.Model;

using Shimakaze.Kernel.Messages.Spans;

namespace Shimakaze.Konata.Messages.Spans;

public sealed record KonataFileSpan : FileSpan
{
    internal readonly FileChain Raw;
    public KonataFileSpan(FileChain raw)
    {
        Raw = raw;
        Name = raw.FileName;
        Size = raw.FileSize;
        Url = raw.FileUrl;
        Hash = raw.FileHash;
    }
}