using CryptoTradingBot.Infrastructure.Binance.Clients;
using Moq.Protected;
using Moq;
using System.Net;
using CryptoTradingBot.Infrastructure.Binance;
using CryptoTradingBot.Core.Models;
using Newtonsoft.Json;

namespace CryptoTradingBot.Infrastructure.Tests.Binance.Clients
{
    public class BinanceSpotApiClientTests
    {
        private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
        private readonly HttpClient _httpClient;
        private readonly MarketDataClient _apiClient;

        public BinanceSpotApiClientTests()
        {
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            _httpClient = new HttpClient(_httpMessageHandlerMock.Object);
            _apiClient = new MarketDataClient(_httpClient, BinanceApiConfig.LoadConfiguration("Test"));
        }

        [Fact]
        public async Task PingAsync_ShouldReturnSuccess()
        {
            // Arrange
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(response);

            // Act
            var result = await _apiClient.PingAsync();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetServerTimeAsync_ShouldReturnServerTime()
        {
            // Arrange
            var jsonResponse = "{\"serverTime\": 1625812800000}";
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(jsonResponse)
            };
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(response);

            // Act
            var serverTime = await _apiClient.GetServerTimeAsync();

            // Assert
            var expected = Convert.ToDateTime(1625812800000);
            Assert.Equal(expected, serverTime);
        }

        [Fact]
        public async Task GetExchangeInfoAsync_ShouldReturnExchangeInfo()
        {
            /*
            // Arrange
            var jsonResponse = "{ \"timezone\": \"UTC\", \"serverTime\": 1625812800000, \"rateLimits\": [], \"symbols\": [] }";
            //return JsonConvert.DeserializeObject<ExchangeInfo>(jsonResponse);

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(jsonResponse)
            };
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(response);

            // Act
            var exchangeInfo = await _apiClient.GetExchangeInfoAsync();

            // Assert
            Assert.NotNull(exchangeInfo);
            Assert.Equal("UTC", exchangeInfo.Timezone);
            Assert.Equal(1625812800000, exchangeInfo.ServerTime);
            */
        }

        [Fact]
        public async Task GetAggregateTradesAsync_ReturnsExpectedResult()
        {
            // Arrange
            var symbol = "BTCUSDT";
            var apiResponse = "[{\"a\":26129,\"p\":\"0.01633102\",\"q\":\"4.70443515\",\"f\":27781,\"l\":27781,\"T\":1498793709153,\"m\":true,\"M\":true}]";
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Get &&
                        req.RequestUri == new Uri($"https://api.binance.com/api/v3/aggTrades?symbol={symbol}")),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(apiResponse),
                });

            // Act
            var result = await _apiClient.GetAggregateTradesAsync(symbol);

            // Assert
            //Assert.NotNull(result);
            //Assert.Single(result);
            //Assert.Equal(26129, result[0].AggregateTradeId);
            //Assert.Equal(0.01633102m, result[0].Price);
            //Assert.Equal(4.70443515m, result[0].Quantity);
            //Assert.Equal(27781, result[0].FirstTradeId);
            //Assert.Equal(27781, result[0].LastTradeId);
            //Assert.Equal(1498793709153, result[0].Timestamp);
            //Assert.True(result[0].IsBuyerMaker);
            //Assert.True(result[0].IsBestPriceMatch);
        }
    }
}