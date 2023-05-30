namespace Shimakaze.Kernel.Events;

public interface IRequestEventArgs
{
    uint ReqId { get; }
    string ReqName { get; }
    uint ReqTime { get; }
    string ReqComment { get; }
    long Token { get; }
}
