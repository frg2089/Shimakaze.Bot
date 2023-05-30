namespace Shimakaze.Kernel.Events;

public abstract class GroupPokeEventArgs : BotEventArgs, IGroupEventArgs, IMemberEventArgs, IOperatorEventArgs
{
    public uint GroupId { get; protected init; }
    public uint MemberId { get; protected init; }
    public uint OperatorId { get; protected init; }
    public string Prefix { get; protected set; } = string.Empty;
    public string Suffix { get; protected set; } = string.Empty;
    protected GroupPokeEventArgs(object raw) : base(raw)
    {
    }
}
