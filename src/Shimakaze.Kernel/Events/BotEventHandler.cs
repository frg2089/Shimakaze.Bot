namespace Shimakaze.Kernel.Events;
public delegate void BotEventHandler<in TEventArgs>(IBot sender, TEventArgs args)
    where TEventArgs : BotEventArgs;
