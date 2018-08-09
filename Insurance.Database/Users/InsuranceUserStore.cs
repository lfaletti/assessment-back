using Microsoft.AspNet.Identity.EntityFramework;

namespace Insurance.Database.Users
{
    public class InsuranceUserStore : UserStore<IdentityUser>, IInsuranceUserStore
    {
        public InsuranceUserStore(InsuranceContext context) : base(context)
        {
        }
    }
}