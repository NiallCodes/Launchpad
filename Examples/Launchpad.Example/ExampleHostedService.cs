using Microsoft.Extensions.Logging;
using NiallCodes.Launchpad.Hosting.Utilities.Services;

namespace Launchpad.Example;

public class ExampleHostedService : HostedService // Implements StartAsync and StopAsync for us!
{
    private readonly ExampleConfig _config;
    private readonly ILogger<ExampleHostedService> _logger;

    // Types bound using BindOptions are also registered under their type.
    public ExampleHostedService(ExampleConfig config, ILogger<ExampleHostedService> logger)
    {
        _config = config;
        _logger = logger;
    }

    public override void Start(CancellationToken cancellationToken) // HostedService provides these sync versions
    {
        _logger.LogInformation("Hello {name}!", _config.Name);
    }
}