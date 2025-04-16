using FlightSearch.Models.Domain.SubModel;
using System.Text.Json.Serialization;

namespace FlightSearch.Models.Domain
{
    public class LocationResponse
    {
        [JsonPropertyName("data")]
        public List<LocationData>? Data { get; set; }
    }
}
