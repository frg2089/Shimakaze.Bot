using Konata.Core.Message.Model;

using Shimakaze.Kernel.Messages.Spans;

namespace Shimakaze.Konata.Messages.Spans;

public sealed record KonataImageSpan : ImageSpan
{
    internal readonly ImageChain Raw;
    public KonataImageSpan(ImageChain raw)
    {
        Raw = raw;
        Url = raw.ImageUrl;
        Name = raw.FileName;
        Hash = raw.HashData;
        Data = raw.FileData;
        Length = raw.FileLength;
        Width = raw.Width;
        Height = raw.Height;
        Type = (Kernel.Messages.Spans.ImageType)raw.Type;
    }
}