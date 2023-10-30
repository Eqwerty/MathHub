using FluentAssertions;
using MathHub.Api.Repositories;
using MathHub.Api.Services;
using Xunit;

namespace MathHub.Api.Tests.Unit;

public class GuidsServiceTests
{
    private readonly GuidsService _guidsService = new GuidsService(new GuidsRepository());

    [Fact]
    public async Task GetAsync_ReturnsEmptyCollection_WhenNoGuidsAdded()
    {
        // Act
        var guids = await _guidsService.GetAsync();

        // Assert
        guids.Should().BeEmpty();
    }

    [Fact]
    public async Task AddAsync_AddsNewGuidToCollection()
    {
        // Act
        var addedGuid = await _guidsService.AddAsync();
        var guids = await _guidsService.GetAsync();

        // Assert
        guids.Should().Equal(addedGuid);
    }

    [Fact]
    public async Task PurgeAsync_ClearsGuidsCollection()
    {
        // Arrange
        await _guidsService.AddAsync();

        // Act
        await _guidsService.PurgeAsync();
        var guids = await _guidsService.GetAsync();

        // Assert
        guids.Should().BeEmpty();
    }
}
