using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Insurance.Database.Users
{
    public class InsuranceUserManager : UserManager<IdentityUser>, IInsuranceUserManager
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