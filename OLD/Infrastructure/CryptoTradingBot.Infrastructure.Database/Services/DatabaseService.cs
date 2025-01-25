using CryptoTradingBot.Infrastructure.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using CryptoTradingBot.Core.Interfaces;

namespace CryptoTradingBot.Infrastructure.Database.Services
{
    public class DatabaseService : IDatabaseService
    {
        public string ConnectionString { get; }

        public DatabaseService(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new SqliteConnection(ConnectionString);
        }
    }
}
