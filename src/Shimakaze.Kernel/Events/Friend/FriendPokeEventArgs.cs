namespace Shimakaze.Kernel.Events;

public abstract class FriendPokeEventArgs : BotEventArgs, IFriendEventArgs
{
    public uint FriendId { get; protected init; }
    public string Prefix { get; protected init; } = string.Empty;
    public string Suffix { get; protected init; } = string.Empty;
    protected FriendPokeEventArgs(object raw) : base(raw)
    {
    }
}
