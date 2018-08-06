using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Insurance.Database.Roles
{
    public class InsuranceRoleManager : RoleManager<IdentityRole>, IInsuranceRoleManager
    {
        public InsuranceRoleManager(InsuranceContext context) : base (new InsuranceRoleStore(context))
        {

        }
    }
}
