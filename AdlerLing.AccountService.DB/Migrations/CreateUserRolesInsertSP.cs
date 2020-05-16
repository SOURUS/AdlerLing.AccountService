using AdlerLing.AccountService.Core.ObjectValue;
using AdlerLing.AccountService.Core.Settings;
using FluentMigrator;
using Microsoft.Extensions.Options;

namespace AdlerLing.AccountService.DB.Migrations
{
    [Migration(7)]
    public class CreateUserRolesInsertSP : Migration
    {
        public readonly string CustomSchema;

        public CreateUserRolesInsertSP(IOptions<DBSettings> _schema)
        {
            CustomSchema = _schema.Value.Schema;
        }

        public override void Up()
        {
            Execute.Sql(@$"
                SET search_path TO {CustomSchema}, public;

                CREATE OR REPLACE PROCEDURE {StoredProcedureVault.sp_insert_user_roles}(user_id UUID, role_id Integer)
                LANGUAGE plpgsql
                AS $$    
                BEGIN
                    INSERT INTO {CustomSchema}.user_roles(user_id, role_id) values (user_id, role_Id);
                END;
                $$;");
        }

        public override void Down()
        {
            Execute.Sql($"DROP PROCEDURE IF EXISTS {CustomSchema}.{StoredProcedureVault.sp_insert_user_roles};");
        }
    }
}
