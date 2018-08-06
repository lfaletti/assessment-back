﻿using Insurance.Database;
using Insurance.Database.Roles;
using Insurance.Database.Users;
using Insurance.IServices.Authentication;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService, IDisposable
    {
        private InsuranceUserManager _userManager;
        private InsuranceRoleManager _roleManager;

        public AuthenticationService(InsuranceContext dbContext)
        {
            _userManager = new InsuranceUserManager(dbContext);
            _roleManager = new InsuranceRoleManager(dbContext);
        }

        /// <summary>
        /// Authenticates the user with the database 
        /// </summary>
        public async Task<bool> Authenticate(string username, string password)
        {
            var user = _userManager.FindByNameAsync(username).Result;

            return await _userManager.CheckPasswordAsync(user, password);
        }

        /// <summary>
        /// Get roles
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<string>> GetRoles(string userId)
        {
            return _userManager.GetRoles(userId).ToList();
        }

        public void Dispose()
        {
        }

        public async Task<IdentityResult> Register(string userName, string password)
        {
            var user = new IdentityUser() { UserName = userName, Email = ""};

            if (!_roleManager.RoleExists("admin"))
            {

                var role = new IdentityRole();
                role.Name = "admin";

                await _roleManager.CreateAsync(role);
            }

            IdentityResult result = await _userManager.CreateAsync(user, password);

            await _userManager.AddToRoleAsync(user.Id, "admin");
            return result;
        }

        public async Task<List<string>> GetAllUsers()
        {
            return _userManager.Users.Select(u => u.UserName).ToList();
        }
    }
}