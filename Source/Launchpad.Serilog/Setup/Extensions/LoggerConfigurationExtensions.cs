using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NiallCodes.Launchpad.Serilog.Setup.Constants;
using Serilog;
using Serilog.Events;

namespace NiallCodes.Launchpad.Serilog.Setup.Extensions;

/// <summary>
/// Extensions for the <see cref="LoggerConfiguration"/> class.
/// </summary>
public static class LoggerConfigurationExtensions
{
    /// <summary>
    /// Adds the console sink to the <see cref="LoggerConfiguration"/>, with a theme and a output template.
    /// </summary>
    /// <param name="config">The <see cref="LoggerConfiguration"/> to add the console sink to.</param>
    /// <param name="minLevel">The minimum level that will be logged.</param>
    public static LoggerConfiguration UseConsoleSink(this LoggerConfiguration config, LogEventLevel minLevel = LogEventLevel.Verbose)
    {
        return config.WriteTo.Console(
            outputTemplate: SerilogSinkTheme.OutputTemplate,
            theme: SerilogSinkTheme.Theme
        ).MinimumLevel.Is(minLevel);
    }
    
    /// <summary>
    /// Applies configuration to Serilog from the <see cref="IConfiguration"/>.
    /// <br/><br/>
    /// See: <a href="https://github.com/serilog/serilog-settings-configuration">Usage Example</a>
    /// </summary>
    /// <param name="config">The <see cref="LoggerConfiguration"/> to apply the configuration to.</param>
    /// <param name="services">The service provider with the <see cref="IConfiguration"/> instance.</param>
    public static LoggerConfiguration UseConfiguration(this LoggerConfiguration config, IServiceProvider services)
    {
        return config.ReadFrom.Configuration(services.GetRequiredService<IConfiguration>());
    }
}