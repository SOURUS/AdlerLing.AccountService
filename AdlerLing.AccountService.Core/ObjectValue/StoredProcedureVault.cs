using System;

namespace AdlerLing.AccountService.Core.ObjectValue
{
    public sealed class StoredProcedureVault
    {
        private readonly String name;
        private readonly int value;

        public static readonly StoredProcedureVault func_insert_user = new StoredProcedureVault(1, "func_insert_user");
        public static readonly StoredProcedureVault sp_insert_user_roles = new StoredProcedureVault(1, "sp_insert_user_roles");

        private StoredProcedureVault(int value, String name)
        {
            this.name = name;
            this.value = value;
        }

        public override String ToString()
        {
            return name;
        }
    }
}
