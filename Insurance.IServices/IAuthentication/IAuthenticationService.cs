﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Insurance.IServices.IAuthentication
{
    public interface IAuthenticationService
    {
        Task<bool> Authenticate(string user, string password);
        Task<IdentityResult> Register(string userName, string password);
        Task<List<string>> GetAllUsers();
    }
}