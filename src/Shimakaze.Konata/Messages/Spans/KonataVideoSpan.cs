using Konata.Core.Message.Model;

using Shimakaze.Kernel.Messages.Spans;

namespace Shimakaze.Konata.Messages.Spans;
public sealed record KonataVideoSpan : VideoSpan
{
    internal readonly VideoChain Raw;
    public KonataVideoSpan(VideoChain raw)
    {
        Raw = raw;
        Url = raw.VideoUrl;
        Name = raw.FileName;
        Hash = raw.FileHash;
        Path = raw.StoragePath;
        Width = raw.Width;
        Height = raw.Height;
        Duration = raw.Duration;
    }
}