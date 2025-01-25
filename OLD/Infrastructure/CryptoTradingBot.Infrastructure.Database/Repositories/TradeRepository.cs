using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using CryptoTradingBot.Infrastructure.Database.Interfaces;
using CryptoTradingBot.Infrastructure.Database.Models;
using CryptoTradingBot.Core.Interfaces;

namespace CryptoTradingBot.Infrastructure.Database.Repositories
{
    public class TradeRepository : BaseRepository<Trade>
    {
        public TradeRepository(IDatabaseService databaseService)
            : base(databaseService, "Trades") { }

        public async Task<IEnumerable<Trade>> GetTradesBySymbolAsync(string symbol)
        {
            using var connection = _databaseService.CreateConnection();
            return await connection.QueryAsync<Trade>("SELECT * FROM Trades WHERE Symbol = @Symbol", new { Symbol = symbol });
        }
    }
}
