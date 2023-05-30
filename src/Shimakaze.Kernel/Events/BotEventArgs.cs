namespace Shimakaze.Kernel.Events;

public abstract class BotEventArgs : EventArgs
{
    protected object _raw;

    protected BotEventArgs(object raw)
    {
        _raw = raw;
    }

    public DateTime Time { get; protected init; }
    public string Description { get; protected init; } = string.Empty;
}
