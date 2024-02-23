using System.Net;
using FluentAssertions;

namespace WebApiVersioningDemo.Tests;

public class IntegrationTests
{
    [Theory]
    [InlineData("api/v1/weathers")]
    [InlineData("api/v2/weathers")]
    [InlineData("api/v3/weathers")]
    [InlineData("api/v3.1/weathers")]
    [InlineData("api/v3.2/weathers")]
    public async Task Should_Get_Weathers_Returns_Ok(string route)
    {
        // arrange
        var fixture = new IntegrationWebApplicationFactory();
        var client = fixture.CreateClient();

        // act
        var response = await client.GetAsync(route);
        var responseBody = await response.Content.ReadAsStringAsync();

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        responseBody.Should().NotBeNullOrWhiteSpace();
    }

    [Theory]
    [InlineData("api/v3.1/weathers/search")]
    [InlineData("api/v3.2/weathers/search")]
    public async Task Should_Search_Weathers_Returns_Ok(string route)
    {
        // arrange
        var fixture = new IntegrationWebApplicationFactory();
        var client = fixture.CreateClient();

        // act
        var response = await client.GetAsync(route);
        var responseBody = await response.Content.ReadAsStringAsync();

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        responseBody.Should().NotBeNullOrWhiteSpace();
    }
    
    [Theory]
    [InlineData("api/v3.2/weathers/full-search")]
    public async Task Should_FullSearch_Weathers_Returns_Ok(string route)
    {
        // arrange
        var fixture = new IntegrationWebApplicationFactory();
        var client = fixture.CreateClient();

        // act
        var response = await client.GetAsync(route);
        var responseBody = await response.Content.ReadAsStringAsync();

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        responseBody.Should().NotBeNullOrWhiteSpace();
    }
}
