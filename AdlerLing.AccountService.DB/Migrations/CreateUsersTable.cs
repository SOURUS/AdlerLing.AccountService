using AdlerLing.AccountService.Core.Settings;
using FluentMigrator;
using Microsoft.Extensions.Options;
using System;

namespace AdlerLing.AccountService.DB.Migrations
{
    [Migration(2)]
    public class CreateUsersTable : Migration
    {
        public readonly string CustomSchema;

        public CreateUsersTable(IOptions<DBSettings> _schema)
        {
            CustomSchema = _schema.Value.Schema;
        }

        public override void Up()
        {
            Create.Table("users").InSchema(CustomSchema)
                .WithColumn("user_id").AsGuid().PrimaryKey()
                .WithColumn("email").AsString(255).NotNullable().Unique()
                .WithColumn("password").AsString(255).NotNullable()
                .WithColumn("creation_date").AsDateTime().WithDefaultValue(SystemMethods.CurrentUTCDateTime).NotNullable()
                .WithColumn("is_activated").AsBoolean().WithDefaultValue(false).NotNullable();

            Execute.Sql($"ALTER Table \"{CustomSchema}\".users ALTER COLUMN user_id SET DEFAULT \"{CustomSchema}\".uuid_generate_v4();");
        }

        public override void Down()
        {
            Delete.Table("users");
        }
    }
}
