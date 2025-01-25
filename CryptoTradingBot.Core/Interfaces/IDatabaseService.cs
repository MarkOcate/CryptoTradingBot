using System.Data;

namespace CryptoTradingBot.Core.Interfaces
{
    public interface IDatabaseService
    {
        string ConnectionString { get; }
        IDbConnection CreateConnection();
    }
}
