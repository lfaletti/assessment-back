using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Insurance.Database.Roles
{
    public interface IInsuranceRoleManager
    {
        bool RoleExists(string roleName);
        Task<IdentityResult> CreateAsync(IdentityRole role);
    }
}