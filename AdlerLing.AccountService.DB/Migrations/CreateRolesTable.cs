using FluentMigrator;
using System;

namespace AdlerLing.AccountService.DB.Migrations
{
    [Migration(3)]
    public class CreateRolesTable : Migration
    {
        public override void Up()
        {
            Create.Table("Roles")
                .WithColumn("RoleId").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(100).Unique().NotNullable()
                .WithColumn("CreationDate").AsDateTime().WithDefaultValue(DateTime.UtcNow).NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Roles");
        }
    }
}
