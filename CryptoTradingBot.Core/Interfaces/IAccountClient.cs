using CryptoTradingBot.Core.Enums.Binance;
using CryptoTradingBot.Core.Models;

namespace CryptoTradingBot.Core.Interfaces
{
    public interface IAccountClient
    {
        Task<AccountInfo> GetAccountInfoAsync();
        Task<IEnumerable<Order>> GetOpenOrdersAsync(string symbol = null);
    }
}