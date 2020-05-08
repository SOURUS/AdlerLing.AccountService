using AdlerLing.AccountService.Core.ObjectValue;
using AdlerLing.AccountService.Core.Settings;
using FluentMigrator;
using Microsoft.Extensions.Options;

namespace AdlerLing.AccountService.DB.Migrations
{
    [Migration(6)]
    public class CreateInsertUserSP : Migration
    {
        public readonly string CustomSchema;

        public CreateInsertUserSP(IOptions<DBSettings> _schema)
        {
            CustomSchema = _schema.Value.Schema;
        }

        public override void Up()
        {
            Execute.Sql(@$"
                SET search_path TO {CustomSchema}, public;

                CREATE OR REPLACE PROCEDURE {StoredProcedureVault.sp_insert_user}(email VARCHAR(255), password VARCHAR(255))
                LANGUAGE plpgsql
                AS $$    
                BEGIN 
                    with new_user as (
                      insert into dbo.users (email, password) VALUES (email, password) RETURNING user_id
                    )
                    insert into dbo.user_info (user_id)
                    values ((select * from new_user));
                END;
                $$; ");
        }

        public override void Down()
        {
            Execute.Sql($"DROP PROCEDURE IF EXISTS {CustomSchema}.{StoredProcedureVault.sp_insert_user};");
        }
    }
}
