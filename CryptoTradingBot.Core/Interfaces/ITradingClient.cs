using CryptoTradingBot.Core.Enums.Binance;
using CryptoTradingBot.Core.Models;

namespace CryptoTradingBot.Core.Interfaces
{
    public interface ITradingClient
    {
        Task<Order> PlaceOrderAsync(NewOrderRequest orderRequest);
        Task<Order> CancelOrderAsync(string symbol, long orderId);
    }

}