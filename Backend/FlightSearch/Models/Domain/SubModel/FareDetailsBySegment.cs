using System.Text.Json.Serialization;

namespace FlightSearch.Models.Domain.SubModel
{
    public class FareDetailsBySegment
    {
        [JsonPropertyName("segmentId")]
        public string? SegmentId { get; set; }

        [JsonPropertyName("cabin")]
        public string? Cabin { get; set; }

        [JsonPropertyName("fareBasis")]
        public string? FareBasis { get; set; }

        [JsonPropertyName("class")]
        public string? ClassFare { get; set; }

        [JsonPropertyName("includedCheckedBags")]
        public IncludedCheckedBags? IncludedCheckedBags { get; set; }
    }
}
