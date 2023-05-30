using System.Diagnostics.CodeAnalysis;

namespace Shimakaze.Kernel.Messages.Spans;

public abstract record QFaceSpan : MessageSpan
{
    private bool _isBig;

    protected QFaceSpan()
    {
        Mode = MessageSpanMode.Multiple;
    }

    public int Id { get; protected init; }
    public string Name { get; protected init; } = string.Empty;
    public bool IsBig
    {
        get => _isBig;
        protected init
        {
            _isBig = value;
            Mode = MessageSpanMode.Singleton;
        }
    }
    [MemberNotNullWhen(true, nameof(IsBig))]
    public int? BigId { get; protected init; }
}
