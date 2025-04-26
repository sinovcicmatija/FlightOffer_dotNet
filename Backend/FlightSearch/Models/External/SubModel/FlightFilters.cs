using System.Text.Json.Serialization;

namespace FlightSearch.Models.External.SubModel
{
    public class FlightFilters
    {
        [JsonPropertyName("cabinRestrictions")]
        public List<CabinRestrictions>? CabinRestrictions { get; set; }
    }
}
