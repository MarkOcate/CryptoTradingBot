using CryptoTradingBot.Core.Interfaces;
using CryptoTradingBot.Core.Models;

namespace CryptoTradingBot.Infrastructure.Binance.Clients
{
    /// <summary>
    /// Account Information
    /// Handles endpoints requiring authentication, such as account and balance information.
    /// </summary>
    public class AccountClient : ApiClientBase, IAccountClient
    {
        public AccountClient(HttpClient httpClient, BinanceApiConfig config) : base(httpClient, config) { }

        Task<AccountInfo> IAccountClient.GetAccountInfoAsync()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Order>> IAccountClient.GetOpenOrdersAsync(string symbol)
        {
            throw new NotImplementedException();
        }

        /*
Endpoints:

/api/v3/account – Account information
/api/v3/myTrades – Account trade list
/api/v3/order – Query order
/api/v3/openOrders – Current open orders
         */
    }


}
