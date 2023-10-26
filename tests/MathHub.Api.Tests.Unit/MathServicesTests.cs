using FluentAssertions;
using MathHub.Api.Services;
using Xunit;

namespace MathHub.Api.Tests.Unit;

public class MathServicesTests
{
    private readonly MathService _mathService = new MathService();

    [Fact]
    public void IsEven_ShouldReturnTrue_WhenZeroIsProvided()
    {
        // Act
        var isEven = _mathService.IsEven(0);

        // Assert
        isEven.Should().BeTrue();
    }

    [Theory]
    [InlineData(2)]
    [InlineData(4)]
    [InlineData(16)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(5000)]
    public void IsEven_ShouldReturnTrue_WhenEvenNumberIsProvided(int number)
    {
        // Act
        var isEven = _mathService.IsEven(number);

        // Assert
        isEven.Should().BeTrue();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(17)]
    [InlineData(101)]
    [InlineData(1001)]
    [InlineData(50001)]
    [InlineData(5000)]
    public void IsEven_ShouldReturnFalse_WhenOddNumberIsProvided(int number)
    {
        // Act
        var isEven = _mathService.IsEven(number);

        // Assert
        isEven.Should().BeFalse();
    }
}
