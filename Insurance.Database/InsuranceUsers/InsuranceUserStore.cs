using Insurance.Database.Contexts;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Insurance.Database.InsuranceUsers
{
    public class InsuranceUserStore : UserStore<IdentityUser>
    {
        public InsuranceUserStore(InsuranceContext context) : base(context)
        {
        }
    }
}