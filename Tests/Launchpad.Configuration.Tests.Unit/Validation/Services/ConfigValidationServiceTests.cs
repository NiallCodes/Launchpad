using NiallCodes.Launchpad.Configuration.Validation.Interfaces;
using NiallCodes.Launchpad.Configuration.Validation.Services;
using NSubstitute;
using Xunit;

namespace Launchpad.Configuration.Tests.Unit.Validation.Services;

public class ConfigValidationServiceTests
{
    [Fact]
    public void Ctor_Should_ValidateConfigs()
    {
        // Arrange
        var configs = Enumerable.Range(0, 5).Select(_ => Substitute.For<IValidatedConfig>()).ToArray();

        // Act
        _ = new ConfigValidationService(configs);

        // Assert
        foreach (var config in configs)
            config.Received(1).ValidateConfig();
    }
}