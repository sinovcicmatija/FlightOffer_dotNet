using System.Text.Json.Serialization;

namespace FlightSearch.Models.External.SubModel
{
    public class SearchCriteria
    {
        [JsonPropertyName("maxFlightOffers")]
        public int MaxFlightOffers { get; set; }

        [JsonPropertyName("flightFilters")]
        public FlightFilters? FlightFilters { get; set; }
    }
}
