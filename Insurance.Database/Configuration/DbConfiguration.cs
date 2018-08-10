using System.Data.Entity.Migrations;

namespace Insurance.Database.Configuration
{
    public class DbConfiguration : DbMigrationsConfiguration<InsuranceContext>
    {
        public DbConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }
    }
}