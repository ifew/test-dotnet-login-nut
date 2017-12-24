using System;
using Xunit;
using API.Controllers;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using API.Services;

namespace API.UnitTests
{
    public class LoginControllerTests
    {
        private User goodRequest;
        private User badRequest;

        public LoginControllerTests()
        {
            goodRequest = new User()
            {
                Username = "ploy",
                Password = "Sck1234"
            };

            badRequest = new User()
            {
                Username = "ploy",
                Password = "qwerty"
            };
        }

        [Fact]
        public void Post_GoodRequest_ReturnsStatusOKWithResults()
        {
            // Arrange
            User expectedUser = new User(){
                Id = 1,
                Username = "ploy",
                Displayname = "พลอย"
            };
            ResponseMessage expectedResponseMessage = new ResponseMessage();
            expectedResponseMessage.Status = "OK";
            expectedResponseMessage.Results = expectedUser;

            StubSuccessAuthenticationService service = new StubSuccessAuthenticationService();
            LoginController controller = new LoginController(service);

            // Act
            ResponseMessage actualResponse = controller.Post(goodRequest);
            User actualUser = actualResponse.Results;

            // Assert
            Assert.IsType<ResponseMessage>(actualResponse);
            Assert.Equal(expectedResponseMessage.Status, actualResponse.Status);
            Assert.IsType<User>(actualUser);
            Assert.Equal(expectedUser.Id, actualUser.Id);
            Assert.Equal(expectedUser.Username, actualUser.Username);
            Assert.Equal(expectedUser.Displayname, actualUser.Displayname);
        }

        [Fact]
        public void Post_BadRequest_ReturnsStatusErrorWithMessage()
        {
            // Arrange
            ResponseMessage expectedResponseMessage = new ResponseMessage()
            {
                Status = "ERROR",
                Message = "User not found"
            };

            StubFailAuthenticationService service = new StubFailAuthenticationService();
            LoginController controller = new LoginController(service);

            // Act
            ResponseMessage actualResponse = controller.Post(badRequest);

            // Assert
            Assert.IsType<ResponseMessage>(actualResponse);
            Assert.Equal(expectedResponseMessage.Status, actualResponse.Status);
            Assert.Equal(expectedResponseMessage.Message, actualResponse.Message);
        }
    }
}
