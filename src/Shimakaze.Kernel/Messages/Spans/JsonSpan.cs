namespace Shimakaze.Kernel.Messages.Spans;

public abstract record JsonSpan : TextSpanBase
{
    protected JsonSpan()
    {
        Mode = MessageSpanMode.Singleton;
    }
}
