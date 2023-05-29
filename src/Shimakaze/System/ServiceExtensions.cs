using System.Reflection;

using Konata.Core.Events.Model;

using Microsoft.Extensions.DependencyInjection;

namespace Shimakaze.System;

internal static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        foreach (var group in AppDomain
            .CurrentDomain
            .GetAssemblies()
            .SelectMany(AssemblyExtensions.GetExportedTypes)
            .Select(t => (
                Metadata: t.GetCustomAttribute<ServiceAttribute>(),
                Type: t
            ))
            .Where(i => i.Metadata is not null)
            .GroupBy(i => i.Metadata?.Type, i => i.Type))
        {
            Func<Type, Type, IServiceCollection> func = group.Key switch
            {
                DependencyInjectionType.Transient => services.AddTransient,
                DependencyInjectionType.Singleton => services.AddSingleton,
                DependencyInjectionType.Scoped => services.AddScoped,
                _ => throw new NotImplementedException(),
            };

            foreach (var type in group)
                func(type, type);
        }
        return services;
    }

    public static IServiceCollection AddHandler(this IServiceCollection services)
    {
        List<Type> handlerTypes = new(){
            typeof(IMessageHandler<FriendMessageEvent>),
            typeof(IMessageHandler<GroupMessageEvent>),
        };

        var types = AppDomain
            .CurrentDomain
            .GetAssemblies()
            .SelectMany(AssemblyExtensions.GetExportedTypes)
            .Where(t => t.IsClass && !t.IsAbstract);

        foreach (var handlerType in handlerTypes)
        {
            foreach (var type in types.Where(type => type.IsAssignableTo(handlerType)))
            {
                services.AddTransient(handlerType, type);
            }
        }

        return services;
    }

}
