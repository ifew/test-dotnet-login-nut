using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace API.IntegrationTests
{
    public class LoginControllerTests
    {
        const string goodRequest = "{\"username\":\"ploy\",\"password\":\"Sck1234\" }";
        const string expectedGoodResponse = "{\"status\":\"OK\",\"results\":{\"id\":1,\"username\":\"ploy\",\"password\":\"Sck1234\",\"displayname\":\"\u0E1E\u0E25\u0E2D\u0E22\"},\"message\":null}";

        const string badRequest = "{\"username\":\"ploy\",\"password\":\"qwerty\" }";
        const string expectedBadResponse = "{\"status\":\"ERROR\",\"results\":null,\"message\":\"User not found\"}";

        const string loginUri = "/api/login";
        const string mediaType = "application/json";

        private readonly TestServer _server;
        private readonly HttpClient _client;
        public LoginControllerTests()
        {
            // Arrange
            _server = new TestServer(
                new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>()
            );
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task Post_BadRequest_ReturnsStatusErrorWithMessage()
        {
            // Arrange
            HttpContent content = new StringContent(badRequest, Encoding.UTF8, mediaType);

            // Act
            var response = await _client.PostAsync(loginUri, content);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(expectedBadResponse, responseString);
        }

        [Fact]
        public async Task Post_GoodRequest_ReturnsStatusOKWithResults()
        {
            // Arrange
            HttpContent content = new StringContent(goodRequest, Encoding.UTF8, mediaType);

            // Act
            var response = await _client.PostAsync(loginUri, content);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(expectedGoodResponse, responseString);
        }
    }
}
