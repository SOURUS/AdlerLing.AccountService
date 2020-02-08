using FluentMigrator;

namespace AdlerLing.AccountService.DB.Migrations
{
    [Migration(1)]
    public class ConfigureDataBaseMigration : Migration
    {
        public override void Up()
        {
            Execute.Sql("CREATE EXTENSION IF NOT EXISTS \"uuid-ossp\";");
        }

        public override void Down()
        {
            Delete.Table("Roles");
        }
    }
}
