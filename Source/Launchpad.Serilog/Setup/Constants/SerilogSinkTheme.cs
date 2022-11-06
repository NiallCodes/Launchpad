using Serilog.Sinks.SystemConsole.Themes;

namespace NiallCodes.Launchpad.Serilog.Setup.Constants;

internal static class SerilogSinkTheme
{
    public const string OutputTemplate = "[{Timestamp:HH:mm:ss}] [{Level}] [{SourceContext}] {Message:lj}{NewLine}{Exception}";
    public static readonly AnsiConsoleTheme Theme = new(new Dictionary<ConsoleThemeStyle, string>
    {
        [ConsoleThemeStyle.Text] = "\u001b[37m",
        [ConsoleThemeStyle.SecondaryText] = "\u001b[37m",
        [ConsoleThemeStyle.TertiaryText] = "\u001b[37m",
        [ConsoleThemeStyle.Invalid] = "\u001b[37m",
        [ConsoleThemeStyle.Null] = "\u001b[37m",
        [ConsoleThemeStyle.Name] = "\u001B[38;5;14m",
        [ConsoleThemeStyle.String] = "\u001B[38;5;10m",
        [ConsoleThemeStyle.Number] = "\u001B[38;5;208m",
        [ConsoleThemeStyle.Boolean] = "\u001B[38;5;13m",
        [ConsoleThemeStyle.Scalar] = "\u001b[37m",
        [ConsoleThemeStyle.LevelVerbose] = "\u001B[38;5;14m",
        [ConsoleThemeStyle.LevelDebug] = "\u001B[38;5;13m",
        [ConsoleThemeStyle.LevelInformation] = "\u001B[38;5;10m",
        [ConsoleThemeStyle.LevelWarning] = "\u001B[38;5;11m",
        [ConsoleThemeStyle.LevelError] = "\u001B[38;5;9m",
        [ConsoleThemeStyle.LevelFatal] = "\u001B[38;5;9m"
    });
}