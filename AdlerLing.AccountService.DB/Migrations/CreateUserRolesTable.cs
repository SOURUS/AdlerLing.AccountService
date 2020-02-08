using FluentMigrator;
using System.Data;

namespace AdlerLing.AccountService.DB.Migrations
{
    [Migration(4)]
    public class CreateUserRolesTable : Migration
    {
        public override void Up()
        {
            Create.Table("UserRoles")
                .WithColumn("UserId").AsGuid()
                .WithColumn("RoleId").AsInt32();

            Create.PrimaryKey("PK_UserRoles")
                .OnTable("UserRoles")
                .Columns("UserId", "RoleId");

            Create.ForeignKey("FK_UserRoles_Users")
                .FromTable("UserRoles").ForeignColumn("UserId")
                .ToTable("Users").PrimaryColumn("UserId")
                .OnDelete(Rule.Cascade);

            Create.ForeignKey("FK_UserRoles_Roles")
                .FromTable("UserRoles").ForeignColumn("RoleId")
                .ToTable("Roles").PrimaryColumn("RoleId")
                .OnDelete(Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table("UserRoles");
        }
    }
}
