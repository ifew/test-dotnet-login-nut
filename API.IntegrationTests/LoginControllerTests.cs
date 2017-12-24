using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Xunit;

namespace API.IntegrationTests
{
    public class LoginControllerTests
    {
        const string loginUri = "/api/login";
        const string mediaType = "application/json";
        const string devEnv = "Development";

        private readonly TestServer _server;
        private readonly HttpClient _client;
        public LoginControllerTests()
        {
            // Arrange
            _server = new TestServer(
                new WebHostBuilder()
                .UseEnvironment(devEnv)
                .UseStartup<Startup>()
            );
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task Post_GoodRequest_ReturnsStatusOKWithResults()
        {
            // Arrange
            string goodRequest = "{\"username\":\"ploy\",\"password\":\"Sck1234\" }";

            HttpContent content = new StringContent(goodRequest, Encoding.UTF8, mediaType);
            User expectedUser = new User()
            {
                Id = 1,
                Username = "ploy",
                Displayname = "พลอย"
            };
            ResponseMessage expectedResponseMessage = new ResponseMessage() 
            {
                Status = "OK",
                Results = expectedUser
            };

            // Act
            var response = await _client.PostAsync(loginUri, content);
            response.EnsureSuccessStatusCode();

            ResponseMessage actualResponseMessage = JsonConvert.DeserializeObject<ResponseMessage>(await response.Content.ReadAsStringAsync());
            User actualUser = actualResponseMessage.Results;

            // Assert
            Assert.IsType<ResponseMessage>(actualResponseMessage);
            Assert.Equal(expectedResponseMessage.Status, actualResponseMessage.Status);
            Assert.IsType<User>(actualUser);
            Assert.Equal(expectedUser.Id, actualUser.Id);
            Assert.Equal(expectedUser.Username, actualUser.Username);
            Assert.Equal(expectedUser.Displayname, actualUser.Displayname);
        }

        [Fact]
        public async Task Post_BadRequest_ReturnsStatusErrorWithMessage()
        {
            // Arrange
            string badRequest = "{\"username\":\"ploy\",\"password\":\"qwerty\" }";

            HttpContent content = new StringContent(badRequest, Encoding.UTF8, mediaType);
            ResponseMessage expectedResponseMessage = new ResponseMessage()
            {
                Status = "ERROR",
                Message = "User not found"
            };

            // Act
            var response = await _client.PostAsync(loginUri, content);
            response.EnsureSuccessStatusCode();

            ResponseMessage actualResponseMessage = JsonConvert.DeserializeObject<ResponseMessage>(await response.Content.ReadAsStringAsync());

            // Assert
            Assert.IsType<ResponseMessage>(actualResponseMessage);
            Assert.Equal(expectedResponseMessage.Status, actualResponseMessage.Status);
            Assert.Equal(expectedResponseMessage.Message, actualResponseMessage.Message);
        }
    }
}
