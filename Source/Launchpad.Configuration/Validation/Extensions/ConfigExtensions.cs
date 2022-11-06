using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NiallCodes.Launchpad.Configuration.Validation.Interfaces;
using NiallCodes.Launchpad.Configuration.Validation.Services;

namespace NiallCodes.Launchpad.Configuration.Validation.Extensions;

/// <summary>
/// Extensions to enable config validation.
/// </summary>
public static class ConfigExtensions
{
    /// <summary>
    /// Adds the ConfigValidationService to the service collection.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to register to.</param>
    /// <returns>The original <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddConfigValidation(this IServiceCollection services)
    {
        return services.AddHostedService<ConfigValidationService>();
    }

    /// <summary>
    /// Adds the ConfigValidationService to the host builder.
    /// </summary>
    /// <param name="builder">The <see cref="IHostBuilder"/> to register to.</param>
    /// <returns>The same instance of the <see cref="IHostBuilder" /> for chaining.</returns>
    public static IHostBuilder UseConfigValidation(this IHostBuilder builder)
    {
        return builder.ConfigureServices((_, services) => services.AddConfigValidation());
    }

    /// <summary>
    /// Registers an option type to the <see cref="IServiceCollection"/> and binds it to a configuration section.
    /// If the type implements the <see cref="IValidatedConfig"/> interface, it's also registered for validation.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to register to.</param>
    /// <param name="configSectionPath">The name of the configuration section to bind to.</param>
    /// <typeparam name="T"> The options type to bind.</typeparam>
    /// <returns>The original <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection BindOptions<T>(this IServiceCollection services, string configSectionPath) where T : class
    {
        services.AddOptions<T>().BindConfiguration(configSectionPath);
        services.AddSingleton(s => s.GetRequiredService<IOptions<T>>().Value);
        if (typeof(IValidatedConfig).IsAssignableFrom(typeof(T)))
            services.AddSingleton(s => (IValidatedConfig) s.GetRequiredService<IOptions<T>>().Value);
        return services;
    }
}