using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Insurance.Database.Users
{
    public class InsuranceUserManager : UserManager<IdentityUser>, IInsuranceUserManager<IdentityUser, string>
    {
        IEnumerable<IdentityUser> IInsuranceUserManager<IdentityUser, string>.Users => base.Users;

        public InsuranceUserManager(InsuranceContext context) : base(new InsuranceUserStore(context))
        {
        }


        public override Task<IdentityUser> FindByNameAsync(string userName)
        {
            return base.FindByNameAsync(userName);
        }

        public IList<string> GetRoles(string userId)
        {
            return base.GetRolesAsync(userId).Result;
        }

        public async override Task<IdentityResult> AddToRoleAsync(string id, string role)
        {
            return await base.AddToRoleAsync(id, role);
        }
    }
}