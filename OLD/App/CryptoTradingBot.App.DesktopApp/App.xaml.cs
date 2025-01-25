using CryptoTradingBot.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using CryptoTradingBot.Infrastructure.DI;
using ApiIntegration.Binance.Services;

namespace CryptoTradingBot.App.DesktopApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            // Build the DI container
            ServiceProvider = new ServiceCollection()
                .RegisterServices()  // Register services using your ServiceRegistry
                .BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            // Resolve and use services
            var logger = ServiceProvider.GetService<ILoggingService>();
            if (logger != null)
            {
                logger.LogInformation("WPF app started.");
            }
            else
            {
                MessageBox.Show("Logger service not available.");
            }

            var configService = ServiceProvider.GetService<BinanceConfigurationService>();
            if (configService != null)
            {
                MessageBox.Show("Binance API Base URL: " + configService.GetBaseUrl());
            }
            else
            {
                MessageBox.Show("Configuration service not available.");
            }

            // Launch the main window
            var mainWindow = ServiceProvider.GetService<MainWindow>();
            if (mainWindow != null)
            {
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("MainWindow service not available.");
                Shutdown();
            }
        }
    }
}
