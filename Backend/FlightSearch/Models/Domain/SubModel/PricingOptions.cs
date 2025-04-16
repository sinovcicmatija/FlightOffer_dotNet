using System.Text.Json.Serialization;

namespace FlightSearch.Models.Domain.SubModel
{
    public class PricingOptions
    {
        [JsonPropertyName("fareType")]
        public string[]? FareType { get; set; }

        [JsonPropertyName("includedCheckedBagsOnly")]
        public bool IncludedCheckedBagsOnly { get; set; }
    }
}
