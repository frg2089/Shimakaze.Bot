using Konata.Core.Message.Model;

using Shimakaze.Kernel.Messages.Spans;

namespace Shimakaze.Konata.Messages.Spans;

public sealed record KonataRecordSpan : RecordSpan
{
    internal readonly RecordChain Raw;
    public KonataRecordSpan(RecordChain raw)
    {
        Raw = raw;
        Id = raw.SelfUin;
        Name = raw.FileName;
        Hash = raw.HashData;
        Data = raw.FileData;
        Length = raw.FileLength;
        TimeSeconds = raw.TimeSeconds;
        Type = (Kernel.Messages.Spans.RecordType)raw.Type;
    }
}