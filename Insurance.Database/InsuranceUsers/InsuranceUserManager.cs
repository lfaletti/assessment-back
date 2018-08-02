using System.Threading.Tasks;
using Insurance.Database.Contexts;
using Insurance.Database.InsuranceUsers.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Insurance.Database.InsuranceUsers
{
    public class InsuranceUserManager : UserManager<IdentityUser>, IInsuranceManager
    {
        public InsuranceUserManager(InsuranceContext context) : base(new InsuranceUserStore(context))
        {
        }

        public override Task<IdentityUser> FindByNameAsync(string userName)
        {
            return base.FindByNameAsync(userName);
        }
    }
}