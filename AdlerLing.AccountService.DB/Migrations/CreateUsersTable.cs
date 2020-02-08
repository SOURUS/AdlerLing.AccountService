using FluentMigrator;
using System;

namespace AdlerLing.AccountService.DB.Migrations
{
    [Migration(2)]
    public class CreateUsersTable : Migration
    {
        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("UserId").AsGuid().PrimaryKey().WithDefault(SystemMethods.NewGuid)
                .WithColumn("Email").AsString(255).Indexed().NotNullable()
                .WithColumn("Password").AsString(255).NotNullable()
                .WithColumn("CreationDate").AsDateTime().WithDefaultValue(DateTime.UtcNow).NotNullable()
                .WithColumn("IsActivated").AsBoolean().WithDefaultValue(false).NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Users");
        }
    }
}
