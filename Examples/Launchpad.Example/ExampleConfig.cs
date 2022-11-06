using System.ComponentModel.DataAnnotations;
using NiallCodes.Launchpad.Configuration.Validation.Models;

namespace Launchpad.Example;

public class ExampleConfig : ValidatedConfig // Inherit from IValidateConfig for validation
{
    [Required] // The ValidatedConfig implementation uses the annotations from System.ComponentModel.DataAnnotations
    public string? Name { get; set; }
}