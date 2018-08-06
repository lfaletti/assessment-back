using Microsoft.AspNet.Identity.EntityFramework;

namespace Insurance.Database.Roles
{
    public class InsuranceRoleStore : RoleStore<IdentityRole>
    {
        public InsuranceRoleStore(InsuranceContext context) : base(context)
        {

        }
    }
}
