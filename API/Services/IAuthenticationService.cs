using System;
using API.Models;

namespace API.Services
{
    public interface IAuthenticationService
    {
        User Login(string username, string password);
    }
}
