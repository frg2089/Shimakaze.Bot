namespace Shimakaze.Kernel.Messages.Spans;

public abstract record AtSpan : MessageSpan
{
    protected AtSpan()
    {
        Mode = MessageSpanMode.Multiple;
    }
    public uint Id { get; protected init; }
}
