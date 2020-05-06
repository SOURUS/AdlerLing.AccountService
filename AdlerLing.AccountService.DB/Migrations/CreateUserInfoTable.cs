using AdlerLing.AccountService.Core.Settings;
using FluentMigrator;
using Microsoft.Extensions.Options;
using System;
using System.Data;

namespace AdlerLing.AccountService.DB.Migrations
{
    [Migration(5)]
    public class CreateUserInfoTable : Migration
    {
        public readonly string CustomSchema;

        public CreateUserInfoTable(IOptions<DBSettings> _schema)
        {
            CustomSchema = _schema.Value.Schema;
        }

        public override void Up()
        {
            Create.Table("user_info").InSchema(CustomSchema)
                .WithColumn("user_id").AsGuid().PrimaryKey()
                .WithColumn("gender").AsString(1).Nullable()
                .WithColumn("age").AsInt16().Nullable()
                .WithColumn("creation_date").AsDateTime().WithDefaultValue(SystemMethods.CurrentUTCDateTime).NotNullable();

            Create.ForeignKey("fk_user_id")
                .FromTable("user_info").InSchema(CustomSchema).ForeignColumn("user_id")
                .ToTable("users").InSchema(CustomSchema).PrimaryColumn("user_id")
                .OnDelete(Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table("user_info");
        }
    }
}
