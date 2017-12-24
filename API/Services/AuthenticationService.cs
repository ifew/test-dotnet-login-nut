using System;
using System.Linq;
using API.Exceptions;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private UserContext userContext;
        public AuthenticationService(UserContext context)
        {
            userContext = context;
        }

        public User Login(string username, string password)
        {
            try
            {
                return userContext.Users.Single(u => u.Username == username && u.Password == password);
            }
            catch (Exception)
            {
                throw new UserNotFoundException("Wrong username or password");
            }
        }
    }
}
