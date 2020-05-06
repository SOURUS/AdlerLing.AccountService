using AdlerLing.AccountService.Core.Settings;
using FluentMigrator;
using Microsoft.Extensions.Options;
using System;

namespace AdlerLing.AccountService.DB.Migrations
{
    [Migration(3)]
    public class CreateRolesTable : Migration
    {
        public readonly string CustomSchema;

        public CreateRolesTable(IOptions<DBSettings> _schema)
        {
            CustomSchema = _schema.Value.Schema;
        }
        public override void Up()
        {
            Create.Table("roles").InSchema(CustomSchema)
                .WithColumn("role_id").AsInt32().PrimaryKey().Identity()
                .WithColumn("name").AsString(100).Unique().NotNullable()
                .WithColumn("creation_date").AsDateTime().WithDefaultValue(SystemMethods.CurrentUTCDateTime).NotNullable();
        }

        public override void Down()
        {
            Delete.Table("roles");
        }
    }
}
