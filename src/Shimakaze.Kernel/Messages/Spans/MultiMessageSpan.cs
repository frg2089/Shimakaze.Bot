
using System.Collections;

namespace Shimakaze.Kernel.Messages.Spans;

public abstract record MultiMessageSpan : XmlSpan, IEnumerable<MessageContent>
{
    public abstract IEnumerator<MessageContent> GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
