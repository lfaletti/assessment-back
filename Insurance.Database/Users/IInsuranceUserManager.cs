
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insurance.Database.Users
{
    public interface IInsuranceUserManager<TUser, Tkey>
    {
        IEnumerable<TUser> Users { get; }

        Task<TUser> FindByNameAsync(string userName);
        Task<IdentityResult> CreateAsync(IdentityUser user, string password);
        Task<IdentityResult> AddToRoleAsync(string id, string role);
        Task<bool> CheckPasswordAsync(IdentityUser user, string password);
        IList<string> GetRoles(string userId);
    }
}
