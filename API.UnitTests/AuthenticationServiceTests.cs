using System;
using Xunit;
using API.Models;
using API.Services;

namespace API.UnitTests
{
    public class AuthenticationServiceTests
    {
        private User successUser;

        public AuthenticationServiceTests()
        {
            successUser = new User()
            {
                Username = "ploy",
                Password = "Sck1234"
            };
        }

        [Fact]
        public void Login_SuccessUser_ReturnsExpectedUser()
        {
            // Arrange
            AuthenticationService service = new AuthenticationService();
            User expectedUser = new User()
            {
                Id = 1,
                Username = "ploy",
                Displayname = "พลอย"
            };

            // Act
            User actualUser = service.Login(successUser.Username, successUser.Password);

            // Assert
            Assert.IsType<User>(actualUser);
            Assert.Equal(expectedUser.Id, actualUser.Id);
            Assert.Equal(expectedUser.Username, actualUser.Username);
            Assert.Equal(expectedUser.Displayname, actualUser.Displayname);
        }
    }
}