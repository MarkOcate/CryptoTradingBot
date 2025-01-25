using CryptoTradingBot.Core.Interfaces;
using CryptoTradingBot.Core.Models;

namespace CryptoTradingBot.Infrastructure.Binance.Clients
{
    /// <summary>
    /// User Data Streams
    /// Manages the user data stream API for receiving real-time updates.
    /// </summary>
    public class UserDataStreamClient : ApiClientBase, IUserDataStreamClient
    {
        public UserDataStreamClient(HttpClient httpClient, BinanceApiConfig config) : base(httpClient, config) { }

        /*
Endpoints:
/api/v3/userDataStream – Start, keep alive, and close a listen key
         */
    }


}
