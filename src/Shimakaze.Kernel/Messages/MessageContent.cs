using System.Collections;

using Shimakaze.Kernel.Messages.Spans;

namespace Shimakaze.Kernel.Messages;

public abstract record MessageContent: IList<MessageSpan>
{
    internal protected readonly List<MessageSpan> _spans = new();

    public MessageSpan this[int index] { get => ((IList<MessageSpan>)_spans)[index]; set => ((IList<MessageSpan>)_spans)[index] = value; }

    public int Count => ((ICollection<MessageSpan>)_spans).Count;

    public bool IsReadOnly => ((ICollection<MessageSpan>)_spans).IsReadOnly;

    public void Add(MessageSpan item)
    {
        ((ICollection<MessageSpan>)_spans).Add(item);
    }

    public void Clear()
    {
        ((ICollection<MessageSpan>)_spans).Clear();
    }

    public bool Contains(MessageSpan item)
    {
        return ((ICollection<MessageSpan>)_spans).Contains(item);
    }

    public void CopyTo(MessageSpan[] array, int arrayIndex)
    {
        ((ICollection<MessageSpan>)_spans).CopyTo(array, arrayIndex);
    }

    public IEnumerator<MessageSpan> GetEnumerator()
    {
        return ((IEnumerable<MessageSpan>)_spans).GetEnumerator();
    }

    public int IndexOf(MessageSpan item)
    {
        return ((IList<MessageSpan>)_spans).IndexOf(item);
    }

    public void Insert(int index, MessageSpan item)
    {
        ((IList<MessageSpan>)_spans).Insert(index, item);
    }

    public bool Remove(MessageSpan item)
    {
        return ((ICollection<MessageSpan>)_spans).Remove(item);
    }

    public void RemoveAt(int index)
    {
        ((IList<MessageSpan>)_spans).RemoveAt(index);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_spans).GetEnumerator();
    }
}
