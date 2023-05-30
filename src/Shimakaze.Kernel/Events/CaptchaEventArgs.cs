using System.Diagnostics.CodeAnalysis;

namespace Shimakaze.Kernel.Events;

public abstract class CaptchaEventArgs : BotEventArgs
{
    public bool IsSlider { get; protected init; }
    public bool IsSMS { get; protected init; }

    [MemberNotNullWhen(true, nameof(IsSlider))]
    public string? SliderUrl { get; protected init; }

    [MemberNotNullWhen(true, nameof(IsSMS))]
    public string? Phone { get; protected init; }

    [MemberNotNullWhen(true, nameof(IsSMS))]
    public string? Country { get; protected init; }
    protected CaptchaEventArgs(object raw) : base(raw)
    {
    }
}
