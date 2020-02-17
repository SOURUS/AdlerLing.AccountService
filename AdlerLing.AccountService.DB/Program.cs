using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentMigrator.Runner;
using System;
using System.IO;
using FluentMigrator.Runner.VersionTableInfo;
using AdlerLing.AccountService.DB.Migrations.Configs;
using AdlerLing.AccountService.Core.Settings;
using Microsoft.Extensions.Configuration.Binder;

namespace AdlerLing.AccountService.DB
{
    class Program
    {
        public static IConfiguration Configuration;

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", optional: true);

            Configuration = builder.Build();

            //TODO: get connection string from Core proj
            var serviceProvider = CreateServices(Configuration["DataBaseInfo:DefaultConnection"]);
            using var scope = serviceProvider.CreateScope();

            UpdateDatabase(scope.ServiceProvider);
        }

        private static IServiceProvider CreateServices(string connectionString)
        {
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .Configure<DBSettings>(option => Configuration.GetSection("DataBaseInfo").Bind(option))
                .AddScoped(typeof(IVersionTableMetaData), typeof(MySchemaName))
                .ConfigureRunner(rb => rb
                    .AddPostgres()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(typeof(Program).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            runner.MigrateUp();
        }
    }
}
