using System;
using API.Models;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace API.IntegrationTests
{
    public class AuthenticationServiceTests
    {
        private User goodUser;
        private User badUser;
        IAuthenticationService service;

        public AuthenticationServiceTests()
        {
            goodUser = new User()
            {
                Username = "ploy",
                Password = "Sck1234"
            };

            badUser = new User()
            {
                Username = "ploy",
                Password = "qwerty"
            };

            var options = new DbContextOptionsBuilder<UserContext>()
                .UseInMemoryDatabase(databaseName: "wallet")
                .Options;
            UserContext context = new UserContext(options);
            context.Users.Add(new User { Username = "ploy", Password = "Sck1234", Displayname = "พลอย" });
            context.SaveChanges();

            service = new AuthenticationService(context);
        }


        [Fact]
        public void Login_GoodUser_ReturnsExpectedUser()
        {
            // Arrange
            User expectedUser = new User()
            {
                Id = 1,
                Username = "ploy",
                Displayname = "พลอย"
            };

            // Act
            User actualUser = service.Login(goodUser.Username, goodUser.Password);

            // Assert
            Assert.IsType<User>(actualUser);
            Assert.Equal(expectedUser.Id, actualUser.Id);
            Assert.Equal(expectedUser.Username, actualUser.Username);
            Assert.Equal(expectedUser.Displayname, actualUser.Displayname);
        }
    }
}
