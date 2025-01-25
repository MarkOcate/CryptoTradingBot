using Microsoft.Extensions.DependencyInjection;
using CryptoTradingBot.Core.Interfaces;
using CryptoTradingBot.Infrastructure.Logging;
using CryptoTradingBot.Infrastructure.Database.Repositories;
using CryptoTradingBot.Infrastructure.Database.Services;
using CryptoTradingBot.Infrastructure.Binance.Services;
using CryptoTradingBot.Infrastructure.Binance.Clients;
using CryptoTradingBot.Core.Models;
using CryptoTradingBot.Application.Services;


namespace CryptoTradingBot.Application
{
    public static class ServiceRegistry
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            // Register Database Service
            services.AddSingleton<IDatabaseService>(provider => new DatabaseService("Data Source=tradingbot.db"));

            // Register core services like logging and database
            services.AddSingleton<ILoggingService, LoggingService>();
            services.AddSingleton<IDatabaseService, DatabaseService>();

            // Register configuration service
            services.AddSingleton<BinanceConfigurationService>();
            //services.AddHttpClient<IBinanceApiClient, BinanceSpotApiClient>();
            services.AddHttpClient<IMarketDataClient, MarketDataClient>();
            services.AddHttpClient<IAccountClient, AccountClient>();
            services.AddHttpClient<ITradingClient, TradingClient>();
            services.AddHttpClient<IUserDataStreamClient, UserDataStreamClient>();

            services.AddTransient<MarketDataService>();

            // Register Repositories
            services.AddSingleton<IRepository<Trade>, TradeRepository>();


            // Register other shared services
            // services.AddSingleton<ISomeOtherService, SomeOtherService>();
            
            // Register MainWindow
            //services.AddTransient<MainWindow>();

            return services;
        }
    }
}
