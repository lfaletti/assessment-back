using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insurance.Services.Authentications
{
    public interface IAuthenticationService
    {
        Task<bool> Authenticate(string user, string password);
        Task<IdentityResult> Register(string userName, string password);
        Task<List<string>> GetAllUsers();
    }
}