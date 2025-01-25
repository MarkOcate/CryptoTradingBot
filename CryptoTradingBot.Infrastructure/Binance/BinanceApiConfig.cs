namespace CryptoTradingBot.Infrastructure.Binance
{
    public class BinanceApiConfig
    {
        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }

        public static BinanceApiConfig LoadConfiguration(string environment)
        {
            return environment.ToLower() switch
            {
                "test" => new BinanceApiConfig
                {
                    BaseUrl = "https://testnet.binance.vision",
                    ApiKey = "your-test-api-key",
                    ApiSecret = "your-test-api-secret"
                },
                "live" => new BinanceApiConfig
                {
                    BaseUrl = "https://api.binance.com",
                    ApiKey = "your-live-api-key",
                    ApiSecret = "your-live-api-secret"
                },
                _ => throw new ArgumentException("Invalid environment specified.")
            };
        }
    }
}
