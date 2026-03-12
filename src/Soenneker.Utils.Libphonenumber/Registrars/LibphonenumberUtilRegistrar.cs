using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Utils.Libphonenumber.Abstract;

namespace Soenneker.Utils.Libphonenumber.Registrars;

/// <summary>
/// An async thread-safe singleton for a libphonenumber-csharp instance
/// </summary>
public static class LibphonenumberUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="ILibphonenumberUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddLibphonenumberUtilAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<ILibphonenumberUtil, LibphonenumberUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="ILibphonenumberUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddLibphonenumberUtilAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<ILibphonenumberUtil, LibphonenumberUtil>();

        return services;
    }
}
