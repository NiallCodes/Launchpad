using Launchpad.Example;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NiallCodes.Launchpad.Configuration.Validation.Extensions;
using NiallCodes.Launchpad.Serilog.Setup.Extensions;
using Serilog;

await Host.CreateDefaultBuilder()

    // Register and setup Serilog.
    .UseSerilog((_, services, config) =>
    {
        config.UseConsoleSink();
        config.UseConfiguration(services);
    })

    // Enable the use of YAML configs.
    .ConfigureAppConfiguration((context, builder) =>
    {
        builder.AddYamlFile("config.yaml", optional: true);
        builder.AddYamlFile($"config.{context.HostingEnvironment.EnvironmentName}.yaml", optional: true);
    })

    // Register the config validation service.
    .UseConfigValidation()

    // Register the options type and hosted service.
    .ConfigureServices(s =>
    {
        s.BindOptions<ExampleConfig>("Example");
        s.AddHostedService<ExampleHostedService>();
    })

    // Start the application.
    .RunConsoleAsync();