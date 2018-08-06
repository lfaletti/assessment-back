using System.Data.Entity;

namespace Insurance.Database.Configuration
{
    public class Initializer : MigrateDatabaseToLatestVersion<InsuranceContext,DbConfiguration>
    {

    }
}