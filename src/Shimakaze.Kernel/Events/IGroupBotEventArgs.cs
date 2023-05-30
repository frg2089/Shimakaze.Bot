namespace Shimakaze.Kernel.Events;

public interface IGroupEventArgs
{
    uint GroupId { get; }
}
public interface IMemberEventArgs
{
    uint MemberId { get; }
}
