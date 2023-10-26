using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace MathHub.Api.Tests.Integration;

public class MathHubApiTests
{
    private readonly WebApplicationFactory<IApiMarker> _webApplicationFactory = new WebApplicationFactory<IApiMarker>();

    [Theory]
    [InlineData("/isEven/4", true)]
    [InlineData("/isEven/7", false)]
    [InlineData("/isEven/0", true)]
    [InlineData("/isEven/1", true)]
    public async Task IsEvenEndpoint_ShouldReturnExpectedResult_WhenValidNumberIsProvided(string route, bool expectedResult)
    {
        //Arrange
        var httpClient = _webApplicationFactory.CreateClient();

        //Act
        var response = await httpClient.GetAsync(route);

        //Assert
        response.Should().HaveStatusCode(HttpStatusCode.OK);
        
        var responseContent = await response.Content.ReadAsStringAsync();
        var actualResponse = bool.Parse(responseContent);
        
        actualResponse.Should().Be(expectedResult);
    }
}
