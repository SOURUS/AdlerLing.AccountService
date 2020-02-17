using AdlerLing.AccountService.Core.Settings;
using FluentMigrator;
using Microsoft.Extensions.Options;
using System.Data;

namespace AdlerLing.AccountService.DB.Migrations
{
    [Migration(4)]
    public class CreateUserRolesTable : Migration
    {
        public readonly string CustomSchema;

        public CreateUserRolesTable(IOptions<DBSettings> _schema)
        {
            CustomSchema = _schema.Value.Schema;
        }

        public override void Up()
        {
            Create.Table("user_roles").InSchema(CustomSchema)
                .WithColumn("user_id").AsGuid()
                .WithColumn("role_id").AsInt32();

            Create.PrimaryKey("pk_user_roles")
                .OnTable("user_roles").WithSchema(CustomSchema)
                .Columns("user_id", "role_id");

            Create.ForeignKey("fk_user_roles_users")
                .FromTable("user_roles").InSchema(CustomSchema).ForeignColumn("user_id")
                .ToTable("users").InSchema(CustomSchema).PrimaryColumn("user_id")
                .OnDelete(Rule.Cascade);

            Create.ForeignKey("fk_user_roles_roles")
                .FromTable("user_roles").InSchema(CustomSchema).ForeignColumn("role_id")
                .ToTable("roles").InSchema(CustomSchema).PrimaryColumn("role_id")
                .OnDelete(Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table("user_roles");
        }
    }
}
