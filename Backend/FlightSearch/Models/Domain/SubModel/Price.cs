using System.Text.Json.Serialization;

namespace FlightSearch.Models.Domain.SubModel
{
    public class Price
    {
        [JsonPropertyName("currency")]
        public string? Currency { get; set; }

        [JsonPropertyName("total")]
        public string? Total { get; set; }

        [JsonPropertyName("base")]
        public string? Base { get; set; }

        [JsonPropertyName("fees")]
        public Fees[]? Fees { get; set; }

        [JsonPropertyName("grandTotal")]
        public string? GrandTotal { get; set; }
    }
}
