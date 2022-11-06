namespace NiallCodes.Launchpad.Configuration.Validation.Interfaces;

/// <summary>
/// A config model with validation logic.
/// </summary>
public interface IValidatedConfig
{
    /// <summary>
    /// Validates this config model.
    /// </summary>
    void ValidateConfig();
}