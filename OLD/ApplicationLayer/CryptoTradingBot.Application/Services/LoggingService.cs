using CryptoTradingBot.Core.Interfaces;

namespace CryptoTradingBot.Infrastructure.Logging
{
    public class LoggingService : ILoggingService
    {
        public void LogInformation(string message)
        {
            Console.WriteLine($"INFO: {message}");
        }

        public void LogWarning(string message)
        {
            Console.WriteLine($"WARNING: {message}");
        }

        public void LogError(string message, Exception exception = null)
        {
            Console.WriteLine($"ERROR: {message}. Exception: {exception?.Message}");
        }
    }
}
