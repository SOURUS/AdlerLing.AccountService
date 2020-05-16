using AdlerLing.AccountService.Core.ObjectValue;
using AdlerLing.AccountService.Core.Settings;
using FluentMigrator;
using Microsoft.Extensions.Options;

namespace AdlerLing.AccountService.DB.Migrations
{
    [Migration(6)]
    public class CreateInsertUserFUNC : Migration
    {
        public readonly string CustomSchema;

        public CreateInsertUserFUNC(IOptions<DBSettings> _schema)
        {
            CustomSchema = _schema.Value.Schema;
        }

        public override void Up()
        {
            Execute.Sql(@$"
                SET search_path TO {CustomSchema}, public;

                CREATE OR REPLACE FUNCTION {CustomSchema}.{StoredProcedureVault.func_insert_user}(email VARCHAR(255), password VARCHAR(255))
                RETURNS UUID
                LANGUAGE plpgsql
                AS $$ 
				DECLARE
   					NewUserID UUID;
                BEGIN 
                    insert into {CustomSchema}.users (email, password) 
					VALUES (email, password) RETURNING user_id into NewUserID;
					
                    insert into {CustomSchema}.user_info (user_id)
                    values (NewUserID);
					
					return (NewUserID);
                END;
                 $$;
                ");
        }

        public override void Down()
        {
            Execute.Sql($"DROP FUNCTION IF EXISTS {CustomSchema}.{StoredProcedureVault.func_insert_user};");
        }
    }
}
