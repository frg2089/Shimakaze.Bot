namespace Shimakaze.Kernel.Messages.Spans;

public abstract record XmlSpan : TextSpanBase
{
    protected XmlSpan()
    {
        Mode = MessageSpanMode.Singleton;
    }
}
