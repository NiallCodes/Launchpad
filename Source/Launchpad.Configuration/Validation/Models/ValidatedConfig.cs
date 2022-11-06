using System.ComponentModel.DataAnnotations;
using NiallCodes.Launchpad.Configuration.Validation.Interfaces;

namespace NiallCodes.Launchpad.Configuration.Validation.Models;

/// <summary>
/// An implementation of <see cref="IValidatedConfig"/> using <see cref="Validator.ValidateObject(object, ValidationContext, bool)"/>.
/// </summary>
public class ValidatedConfig : IValidatedConfig
{
    /// <inheritdoc cref="IValidatedConfig.ValidateConfig"/>
    public void ValidateConfig()
    {
        try
        {
            Validator.ValidateObject(this, new ValidationContext(this), true);
        }
        catch (ValidationException error)
        {
            // To make the exception more helpful, append the name of the config class.
            var errorMessage = $"{GetType().Name}: {error.ValidationResult.ErrorMessage}";
            var validationResult = new ValidationResult(errorMessage, error.ValidationResult.MemberNames);
            throw new ValidationException(validationResult, error.ValidationAttribute, error.Value);
        }
    }
}