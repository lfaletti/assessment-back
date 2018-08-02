using Insurance.Database.Contexts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Insurance.Database.InsuranceUsers
{
    public class InsuranceRoleManager : RoleManager<IdentityRole>
    {
        public InsuranceRoleManager(InsuranceContext context) : base (new InsuranceRoleStore(context))
        {

        }
    }
}
