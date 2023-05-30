using Konata.Core.Message.Model;

using Shimakaze.Kernel.Messages.Spans;

namespace Shimakaze.Konata.Messages.Spans;

public sealed record KonataQFaceSpan : QFaceSpan
{
    internal readonly QFaceChain Raw;
    public KonataQFaceSpan(QFaceChain raw)
    {
        Raw = raw;
        Id = raw.FaceId;
        Name = raw.FaceName;
        IsBig = raw.Big;
        if (int.TryParse(raw.BigFaceId, out var i))
            BigId = i;
    }
}