using System;
using API.Exceptions;
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

            // Context
            var options = new DbContextOptionsBuilder<UserContext>()
                .UseInMemoryDatabase(databaseName: "wallet")
                .Options;
            using (var context = new UserContext(options))
            {
                context.Users.Add(new User { Username = "ploy", Password = "Sck1234", Displayname = "พลอย" });
                context.SaveChanges();
                IAuthenticationService service = new AuthenticationService(context);

                // Act
                User actualUser = service.Login(goodUser.Username, goodUser.Password);

                // Assert
                Assert.IsType<User>(actualUser);
                Assert.Equal(expectedUser.Id, actualUser.Id);
                Assert.Equal(expectedUser.Username, actualUser.Username);
                Assert.Equal(expectedUser.Displayname, actualUser.Displayname);
            }
        }

        [Fact]
        public void Login_BadUser_ThrowUserNotFoundException()
        {
            try
            {
                // Context
                var options = new DbContextOptionsBuilder<UserContext>()
                    .UseInMemoryDatabase(databaseName: "wallet")
                    .Options;
                using (var context = new UserContext(options))
                {
                    IAuthenticationService service = new AuthenticationService(context);

                    // Act
                    service.Login(badUser.Username, badUser.Password);

                    // Assert
                    Assert.True(false, "UserNotFoundException was not thrown");
                }
            }
            catch (UserNotFoundException)
            {
                // Assert
                Assert.True(true);
            }
        }
    }
}
