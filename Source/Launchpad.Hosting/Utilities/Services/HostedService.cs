using Microsoft.Extensions.Hosting;

namespace NiallCodes.Launchpad.Hosting.Utilities.Services;

/// <summary>
/// A wrapper around <see cref="IHostedService"/> which implements all interface methods.
/// </summary>
public class HostedService : IHostedService
{
    /// <inheritdoc cref="IHostedService.StartAsync"/>
    public virtual Task StartAsync(CancellationToken cancellationToken)
    {
        Start(cancellationToken);
        return Task.CompletedTask;
    }

    /// <inheritdoc cref="IHostedService.StopAsync"/>
    public virtual Task StopAsync(CancellationToken cancellationToken)
    {
        Stop(cancellationToken);
        return Task.CompletedTask;
    }

    /// <inheritdoc cref="IHostedService.StartAsync"/>
    public virtual void Start(CancellationToken cancellationToken)
    {
    }

    /// <inheritdoc cref="IHostedService.StopAsync"/>
    public virtual void Stop(CancellationToken cancellationToken)
    {
    }
}