using Insurance.Database.Contexts;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Insurance.Database.InsuranceUsers
{
    public class InsuranceRoleStore : RoleStore<IdentityRole>
    {
        public InsuranceRoleStore(InsuranceContext context) : base(context)
        {

        }
    }
}
