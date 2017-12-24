using System;
using Xunit;
using API.Controllers;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.UnitTests
{
    public class LoginControllerTest
    {
        const string goodJson = "{ \"username\": \"ploy\", \"password\": \"Sck1234\" }";

        [Fact]
        public void Post_GoodJson_ReturnsExpectedUser()
        {
            // Arrange
            LoginController controller = new LoginController();
            User expectedUser = new User(){
                Id = 1,
                Username = "ploy",
                Displayname = "พลอย"
            };

            // Act
            var actualUser = controller.Post(goodJson);

            // Assert
            Assert.IsType<User>(actualUser);
            Assert.Equal(expectedUser.Id, actualUser.Id);
            Assert.Equal(expectedUser.Username, actualUser.Username);
            Assert.Equal(expectedUser.Displayname, actualUser.Displayname);
        }
    }
}
