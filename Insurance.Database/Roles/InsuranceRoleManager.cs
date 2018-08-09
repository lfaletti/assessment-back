using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace Insurance.Database.Roles
{
    public class InsuranceRoleManager : RoleManager<IdentityRole>, IInsuranceRoleManager
    {
        public InsuranceRoleManager(InsuranceContext context) : base (new InsuranceRoleStore(context))
        {

        }

        public bool RoleExists(string roleName)
        {
            return base.RoleExistsAsync(roleName).Result;
        }

        public async override Task<IdentityResult> CreateAsync(IdentityRole role)
        {
            return await base.CreateAsync(role);
        }
    }
}
