using System.Text.Json.Serialization;

namespace FlightSearch.Models.Domain.SubModel
{
    public class Fees
    {
        [JsonPropertyName("amount")]
        public string? Amount { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }
}
