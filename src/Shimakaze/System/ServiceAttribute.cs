namespace Shimakaze.System;

[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
public sealed class ServiceAttribute : Attribute
{
    public DependencyInjectionType Type { get; }

    public ServiceAttribute(DependencyInjectionType type)
    {
        Type = type;
    }

    public ServiceAttribute() : this(DependencyInjectionType.Transient)
    {
    }
}
