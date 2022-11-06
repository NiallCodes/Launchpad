using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using NiallCodes.Launchpad.Configuration.Validation.Models;
using Xunit;

namespace Launchpad.Configuration.Tests.Unit.Validation.Models;

public class ValidatedConfigTests
{
    private class MockConfig : ValidatedConfig
    {
        [Required]
        public string? Name { get; set; }
    }

    [Fact]
    public void ValidateConfig_Should_NotThrow_When_ConfigValid()
    {
        // Arrange
        var config = new MockConfig { Name = "Nick" };

        // Act
        var act = () => config.ValidateConfig();

        // Assert
        act.Should().NotThrow();
    }

    [Fact]
    public void ValidateConfig_Should_Throw_When_ConfigInvalid()
    {
        // Arrange
        var config = new MockConfig();

        // Act
        var act = () => config.ValidateConfig();

        // Assert
        act.Should()
            .Throw<ValidationException>()
            .Where(x => x.ValidationResult.ErrorMessage != null)
            .Where(x => x.ValidationResult.ErrorMessage!.Contains("MockConfig"));
    }
}