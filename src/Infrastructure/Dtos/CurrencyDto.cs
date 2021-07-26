using System.Text.Json.Serialization;

namespace CTechnology.BookPricingApi.Dtos
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CurrencyDto
    {
        EUR = 1, USD = 2
    }
}