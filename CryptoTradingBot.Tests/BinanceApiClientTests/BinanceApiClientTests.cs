using CryptoTradingBot.Infrastructure.ApiIntegration.Binance;
using Moq;
using Moq.Protected;
using System.Net;

namespace CryptoTradingBot.Tests
{
    public class BinanceApiClientTests
    {
        [Fact]
        public async Task TestConnectionAsync_ShouldReturnTrue_WhenPingIsSuccessful()
        {
            // Arrange
            var config = new BinanceApiConfig
            {
                BaseUrl = "https://testnet.binance.vision",
                ApiKey = "test-api-key"
            };

            // Mock the HttpClient
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK
                });

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri(config.BaseUrl)
            };

            var apiClient = new BinanceApiClient(httpClient, config);

            // Act
            var result = await apiClient.TestConnectionAsync();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task TestConnectionAsync_ShouldReturnFalse_WhenPingFails()
        {
            // Arrange
            var config = new BinanceApiConfig
            {
                BaseUrl = "https://testnet.binance.vision",
                ApiKey = "test-api-key"
            };

            // Mock the HttpClient
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest
                });

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri(config.BaseUrl)
            };

            var apiClient = new BinanceApiClient(httpClient, config);

            // Act
            var result = await apiClient.TestConnectionAsync();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task TestConnectionAsync_ShouldReturnFalse_WhenExceptionOccurs()
        {
            // Arrange
            var config = new BinanceApiConfig
            {
                BaseUrl = "https://testnet.binance.vision",
                ApiKey = "test-api-key"
            };

            // Mock the HttpClient to throw an exception
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ThrowsAsync(new HttpRequestException("Network error"));

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri(config.BaseUrl)
            };

            var apiClient = new BinanceApiClient(httpClient, config);

            // Act
            var result = await apiClient.TestConnectionAsync();

            // Assert
            Assert.False(result);
        }
    }
}