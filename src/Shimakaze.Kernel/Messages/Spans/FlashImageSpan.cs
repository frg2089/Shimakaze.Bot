namespace Shimakaze.Kernel.Messages.Spans;

public abstract record FlashImageSpan : ImageSpan
{
    protected FlashImageSpan()
    {
        Mode = MessageSpanMode.Singleton;
    }
}
