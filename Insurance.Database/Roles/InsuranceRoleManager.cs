using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Insurance.Database.Roles
{
    public class InsuranceRoleManager : RoleManager<IdentityRole>, IInsuranceRoleManager
    {
        public InsuranceRoleManager(InsuranceContext context) : base(new InsuranceRoleStore(context))
        {
        }

        public bool RoleExists(string roleName)
        {
            return RoleExistsAsync(roleName).Result;
        }

        public override async Task<IdentityResult> CreateAsync(IdentityRole role)
        {
            return await base.CreateAsync(role);
        }
    }
}