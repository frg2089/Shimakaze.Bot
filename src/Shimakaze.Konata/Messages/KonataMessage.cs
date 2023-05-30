using Konata.Core.Message;

using Shimakaze.Kernel.Messages;

namespace Shimakaze.Konata.Messages;

public sealed record KonataMessage : Message
{
    internal readonly MessageStruct Raw;
    public KonataMessage(MessageStruct raw)
    {
        Raw = raw;
        Time = DateTime.FromBinary(raw.Time);
        Sequence = raw.Sequence;
        Uuid = raw.Uuid;
        Random = raw.Random;
        Type = (SourceType)raw.Type;
        Sender = new(raw.Sender.Uin, raw.Sender.Name);
        Receiver = new(raw.Receiver.Uin, raw.Receiver.Name);
        Content = new KonataMessageContent(raw.Chain);
    }
    public override string ToString()
    {
        return string.Join(' ', Raw.Chain.Select(i => i.ToString()));
    }
}