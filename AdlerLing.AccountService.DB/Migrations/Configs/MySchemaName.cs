using AdlerLing.AccountService.Core.Settings;
using FluentMigrator.Runner.VersionTableInfo;
using Microsoft.Extensions.Options;

namespace AdlerLing.AccountService.DB.Migrations.Configs
{
    [VersionTableMetaData]
    [System.Obsolete]
    public class MySchemaName : DefaultVersionTableMetaData
    {
        public readonly string Schema;
        public MySchemaName(IOptions<DBSettings> _schema)
        {
            Schema = _schema.Value.Schema;
        }
        
        public override string SchemaName
        {
            get { return Schema; }
        }
    }
}
