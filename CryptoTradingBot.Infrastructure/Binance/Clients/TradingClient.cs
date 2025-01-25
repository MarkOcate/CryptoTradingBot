using CryptoTradingBot.Core.Interfaces;
using CryptoTradingBot.Core.Models;

namespace CryptoTradingBot.Infrastructure.Binance.Clients
{
    /// <summary>
    /// Trading
    /// Handles order placement and trading functionality.
    /// </summary>
    public class TradingClient : ApiClientBase, ITradingClient
    {
        public TradingClient(HttpClient httpClient, BinanceApiConfig config) : base(httpClient, config) { }

        Task<Order> ITradingClient.CancelOrderAsync(string symbol, long orderId)
        {
            throw new NotImplementedException();
        }

        Task<Order> ITradingClient.PlaceOrderAsync(NewOrderRequest orderRequest)
        {
            throw new NotImplementedException();
        }

        /*
Endpoints:

/api/v3/order – Place a new order
/api/v3/order/test – Test new order creation
/api/v3/openOrders – Query all open orders
/api/v3/allOrders – Query all orders
         */
    }


}
