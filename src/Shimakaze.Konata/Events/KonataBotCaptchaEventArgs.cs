using Konata.Core.Events.Model;

using Shimakaze.Kernel.Events;

namespace Shimakaze.Konata.Events;

public sealed class KonataBotCaptchaEventArgs : CaptchaEventArgs
{
    public KonataBotCaptchaEventArgs(CaptchaEvent raw) : base(raw)
    {
        Time = raw.EventTime;
        Description = raw.EventMessage;
        IsSlider = raw.Type is CaptchaEvent.CaptchaType.Slider;
        IsSMS = raw.Type is CaptchaEvent.CaptchaType.Sms;
        SliderUrl = raw.SliderUrl;
        Phone = raw.Phone;
        Country = raw.Country;
    }
}