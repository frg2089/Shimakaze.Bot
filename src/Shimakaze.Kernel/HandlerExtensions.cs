
using System.Reflection;

using Microsoft.Extensions.DependencyInjection;

using Shimakaze.Kernel.Events;

namespace Shimakaze.Kernel;

public static class HandlerExtensions
{
    public static IServiceCollection AddHandler(this IServiceCollection services)
    {
        var types = AppDomain
            .CurrentDomain
            .GetAssemblies()
            .SelectMany(AssemblyExtensions.GetExportedTypes)
            .Where(t => t.IsClass && !t.IsAbstract)
            .Where(t => t.IsAssignableTo(typeof(IMessageHandler)));

        foreach (var type in types)
        {
            foreach (var @interface in type
                .GetInterfaces()
                .Where(i => i.IsAssignableTo(typeof(IMessageHandler)) && type != typeof(IMessageHandler)))
            {
                services.AddTransient(@interface, type);
            }
        }

        return services;
    }
}