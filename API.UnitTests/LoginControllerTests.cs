using System;
using Xunit;
using API.Controllers;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.UnitTests
{
    public class LoginControllerTests
    {
        private User goodRequest;
        private LoginController controller;

        public LoginControllerTests()
        {
            goodRequest = new User()
            {
                Username = "ploy",
                Password = "Sck1234"
            };

            controller = new LoginController();
        }

        [Fact]
        public void Post_GoodRequest_ReturnsExpectedUser()
        {
            // Arrange
            User expectedUser = new User(){
                Id = 1,
                Username = "ploy",
                Displayname = "พลอย"
            };

            // Act
            var actualUser = controller.Post(goodRequest);

            // Assert
            Assert.IsType<User>(actualUser);
            Assert.Equal(expectedUser.Id, actualUser.Id);
            Assert.Equal(expectedUser.Username, actualUser.Username);
            Assert.Equal(expectedUser.Displayname, actualUser.Displayname);
        }
    }
}
