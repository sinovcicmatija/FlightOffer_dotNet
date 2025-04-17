using FlightSearch.Models.External.SubModel;
using System.Text.Json.Serialization;

namespace FlightSearch.Models.External
{
    public class FlightOfferCallModel
    {
        [JsonPropertyName("currencyCode")]
        public string? CurrencyCode { get; set; }

        [JsonPropertyName("originDestinations")]
        public OriginDestinations[]? OriginDestinations { get; set; }

        [JsonPropertyName("travelers")]
        public Travelers[]? Travelers { get; set; }

        [JsonPropertyName("sources")]
        public string[]? Sources { get; set; }

        [JsonPropertyName("searchCriteria")]
        public SearchCriteria? SearchCriteria { get; set; }
    }
}
