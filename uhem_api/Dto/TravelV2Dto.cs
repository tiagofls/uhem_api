using System.Text.Json.Serialization;

namespace uhem_api.Dto
{
    public class TravelV2Dto
    {
        [JsonPropertyName("date")]
        public string? Date { get; set; }

        [JsonPropertyName("purpose")]
        public string? Purpose { get; set; }

        [JsonPropertyName("facility")]
        public string? Facility { get; set; }

        [JsonPropertyName("start")]
        public string? Start { get; set; }

        [JsonPropertyName("duration")]
        public string? Duration { get; set; }
    }
}
