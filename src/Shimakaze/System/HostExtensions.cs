using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shimakaze.System;

internal static class HostExtensions
{
    public static T Bind<T>(this IConfiguration configuration, string key) where T : new()
    {
        T t = new();
        configuration.Bind(key, t);
        return t;
    }
}
