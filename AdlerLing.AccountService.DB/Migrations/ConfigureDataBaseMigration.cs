using AdlerLing.AccountService.Core.Settings;
using FluentMigrator;
using Microsoft.Extensions.Options;

namespace AdlerLing.AccountService.DB.Migrations
{
    [Migration(1)]
    public class ConfigureDataBaseMigration : Migration
    {
        public readonly string CustomSchema;

        public ConfigureDataBaseMigration(IOptions<DBSettings> _schema)
        {
            CustomSchema = _schema.Value.Schema;
        }

        public override void Up()
        {
            Execute.Sql($"CREATE EXTENSION IF NOT EXISTS \"uuid-ossp\" SCHEMA {CustomSchema}");
        }

        public override void Down()
        {
            Execute.Sql($"DROP EXTENSION \"uuid-ossp\" SCHEMA {CustomSchema}");   
        }
    }
}
