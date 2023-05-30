namespace Shimakaze.Kernel.Messages.Spans;

public abstract record TextSpan : TextSpanBase
{
    protected TextSpan()
    {
        Mode = MessageSpanMode.Multiple;
    }
}
