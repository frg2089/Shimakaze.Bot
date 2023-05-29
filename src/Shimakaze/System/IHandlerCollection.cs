namespace Shimakaze.System;

internal interface IHandlerCollection
{
    IHandlerCollection AddRange(IEnumerable<Type> types);
}

internal sealed class HandlerCollection<TMessageHandler>
    : List<TMessageHandler>, IHandlerCollection
    where TMessageHandler : IMessageHandler
{
    public IHandlerCollection AddRange(IEnumerable<Type> types)
    {
        AddRange(types.Where(t => t.IsAssignableTo(typeof(TMessageHandler))));
        return this;
    }
}