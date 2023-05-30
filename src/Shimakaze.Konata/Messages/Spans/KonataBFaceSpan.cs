using Konata.Core.Message.Model;

using Shimakaze.Kernel.Messages.Spans;

namespace Shimakaze.Konata.Messages.Spans;

public sealed record KonataBFaceSpan : BFaceSpan
{
    internal readonly BFaceChain Raw;
    public KonataBFaceSpan(BFaceChain raw)
    {
        Raw = raw;
        Name = raw.Name;
        Id = raw.FaceId;
        Hash = raw.HashData;
    }
}