using Microsoft.Extensions.Hosting;
using NiallCodes.Launchpad.Configuration.Validation.Interfaces;

namespace NiallCodes.Launchpad.Configuration.Validation.Services;

/// <summary>
/// A service which validates <see cref="IValidatedConfig"/> upon creation.
/// </summary>
internal class ConfigValidationService : IHostedService
{
    public ConfigValidationService(IEnumerable<IValidatedConfig> configs)
    {
        foreach (var config in configs)
            config.ValidateConfig();
    }

    public Task StartAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}