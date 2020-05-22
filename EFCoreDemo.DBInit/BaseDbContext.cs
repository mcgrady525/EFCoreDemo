using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemo.DBInit
{
    public class BaseDbContext : DbContext
    {
        bool _isLogging;
        string _dbName;

        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                .AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information)
                .AddConsole();
        });

        public string ConnString
        {
            get
            {
                IConfigurationBuilder builder = new ConfigurationBuilder();
                builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);//reloadOnChange:true当配置更新了程序自动更新
                IConfigurationRoot configRoot = builder.Build();

                return ConfigurationExtensions.GetConnectionString(configRoot, _dbName);
            }
        }

        public BaseDbContext(string dbName, bool isLogging = false, bool isNoLock = false) : base()
        {
            _isLogging = isLogging;
            _dbName = dbName;

            if (isNoLock)
            {
                Database.ExecuteSqlRaw("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if (_isLogging)
                {
                    optionsBuilder = optionsBuilder.UseLoggerFactory(loggerFactory).EnableSensitiveDataLogging();
                }
                optionsBuilder.UseSqlServer(ConnString);
            }
        }
    }
}
