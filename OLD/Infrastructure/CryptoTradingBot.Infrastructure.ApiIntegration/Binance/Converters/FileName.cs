using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CryptoTradingBot.Infrastructure.ApiIntegration.Binance.Enums;
using CryptoTradingBot.Infrastructure.ApiIntegration.Binance.Filters;

namespace CryptoTradingBot.Infrastructure.ApiIntegration.Binance.Converters
{
    public class SymbolFilterConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(SymbolFilter);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var filterType = jsonObject["filterType"].ToString();

            SymbolFilter filter = filterType switch
            {
                "PRICE_FILTER" => new PriceFilter(),
                "PERCENT_PRICE" => new PercentPriceFilter(),
                "LOT_SIZE" => new LotSizeFilter(),
                // Add cases for other filter types...
                _ => throw new NotSupportedException($"Filter type '{filterType}' is not supported.")
            };

            serializer.Populate(jsonObject.CreateReader(), filter);
            return filter;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
