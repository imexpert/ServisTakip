using ServisTakip.Core.Utilities.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Data;
using Serilog.Events;

namespace ServisTakip.Core.CrossCuttingConcerns.Logging.Serilog.Loggers
{
    public class MsSqlLogger : LoggerServiceBase
    {
        public MsSqlLogger()
        {
            var configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();

            string connectionString = configuration.GetConnectionString("ServisTakipContext");

            var sinkOpts = new MSSqlServerSinkOptions
            {
                TableName = "ErrorLogs",
                SchemaName = "dbo",
                AutoCreateSqlTable = true
            };

            var columnOpts = new ColumnOptions();

            SqlColumn userMail = new SqlColumn
            {
                DataType = SqlDbType.NVarChar,
                ColumnName = "UserMail",
                AllowNull = true,
                DataLength = 100
            };

            SqlColumn userId = new SqlColumn
            {
                DataType = SqlDbType.BigInt,
                ColumnName = "UserId",
                AllowNull = true,
            };

            SqlColumn companyId = new SqlColumn
            {
                DataType = SqlDbType.BigInt,
                ColumnName = "CompanyId",
                AllowNull = true
            };

            SqlColumn clientIp = new SqlColumn
            {
                DataType = SqlDbType.NVarChar,
                ColumnName = "ClientIp",
                AllowNull = true,
                DataLength = 100
            };

            columnOpts.AdditionalColumns = new List<SqlColumn>
            {
                userMail,
                userId,
                companyId,
                clientIp
            };

            columnOpts.Store.Remove(StandardColumn.MessageTemplate);
            columnOpts.Store.Remove(StandardColumn.Properties);

            Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
                .WriteTo.MSSqlServer(
                    connectionString,
                    sinkOptions: sinkOpts, 
                    null, 
                    null,
                    restrictedToMinimumLevel: LogEventLevel.Warning, 
                    null,
                    columnOptions: columnOpts, 
                    null, 
                    null)
                .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                .CreateLogger();

            Logger = Log.Logger;
        }
    }
}
