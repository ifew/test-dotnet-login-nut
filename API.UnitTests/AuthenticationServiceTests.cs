﻿using System;
using Xunit;
using API.Models;
using API.Services;
using API.Exceptions;

namespace API.UnitTests
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
        public void Login_SuccessUser_ReturnsExpectedUser()
        {
            // Arrange
            User expectedUser = new User()
            {
                Id = 1,
                Username = "ploy",
                Displayname = "พลอย"
            };
            IAuthenticationService service = service = new StubSuccessAuthenticationService();

            // Act
            User actualUser = service.Login(goodUser.Username, goodUser.Password);

            // Assert
            Assert.IsType<User>(actualUser);
            Assert.Equal(expectedUser.Id, actualUser.Id);
            Assert.Equal(expectedUser.Username, actualUser.Username);
            Assert.Equal(expectedUser.Displayname, actualUser.Displayname);
        }

        [Fact]
        public void Login_BadUser_ThrowUserNotFoundException()
        {
            try
            {
                // Arrange
                IAuthenticationService service = service = new StubFailAuthenticationService();

                // Act
                service.Login(badUser.Username, badUser.Password);

                // Assert
                Assert.True(false, "UserNotFoundException was not thrown");
            }
            catch (UserNotFoundException)
            {
                // Assert
                Assert.True(true);
            }

        }
    }
}