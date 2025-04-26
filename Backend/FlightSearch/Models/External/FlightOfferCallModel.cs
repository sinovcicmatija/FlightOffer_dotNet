using FlightSearch.Models.External.SubModel;
using System.Text.Json.Serialization;

namespace FlightSearch.Models.External
{
    public class FlightOfferCallModel
    {
        [JsonPropertyName("currencyCode")]
        public string? CurrencyCode { get; set; }

        [JsonPropertyName("originDestinations")]
        public List<OriginDestinations>? OriginDestinations { get; set; }

        [JsonPropertyName("travelers")]
        public List<Travelers>? Travelers { get; set; }

        [JsonPropertyName("sources")]
        public List<string>? Sources { get; set; }

        [JsonPropertyName("searchCriteria")]
        public SearchCriteria? SearchCriteria { get; set; }
    }
}
