using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace MathHub.Api.Tests.Integration;

public class GuidsServiceTests
{
    private readonly WebApplicationFactory<IApiMarker> _webApplicationFactory = new WebApplicationFactory<IApiMarker>();

    [Fact]
    public async Task GuidsService_ReturnsCorrectResponses_WhenRequested()
    {
        //Arrange
        var httpClient = _webApplicationFactory.CreateClient();
        var baseUri = "guids";

        //Act
        var postResponse = await httpClient.PostAsync(baseUri, new StringContent(string.Empty));
        var guidAsString = await postResponse.Content.ReadAsStringAsync();
        var guidAdded = Guid.Parse(guidAsString.Replace("\"", ""));

        var getResponse = await httpClient.GetAsync(baseUri);
        var guidsInDb = await getResponse.Content.ReadFromJsonAsync<IReadOnlyCollection<Guid>>();

        var deleteResponse = await httpClient.DeleteAsync(baseUri);

        //Assert
        guidsInDb.Should().ContainSingle().Which.Should().Be(guidAdded);
        deleteResponse.Should().HaveStatusCode(HttpStatusCode.NoContent);

        var emptyResponse = await httpClient.GetAsync(baseUri);
        var emptyGuidsInDb = await emptyResponse.Content.ReadFromJsonAsync<IReadOnlyCollection<Guid>>();
        emptyGuidsInDb.Should().BeEmpty();
    }
}
