﻿using System;
using API.Exceptions;
using API.Models;

namespace API.Services
{
    public class AuthenticationService
    {
        public User Login(string username, string password)
        {
            if (username != "ploy" || password != "Sck1234")
            {
                throw new UserNotFoundException("Wrong username or password");
            }

            return new User()
            {
                Id = 1,
                Username = "ploy",
                Displayname = "พลอย"
            };
        }
    }
}
