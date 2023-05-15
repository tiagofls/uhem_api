using System.Text.Json.Serialization;

namespace uhem_api.Dto
{
    public class TravelDto
    {
        [JsonPropertyName("id_travel")]
        public int? IdTravel { get; set; }

        [JsonPropertyName("id_driver")]
        public int? IdDriver { get; set; }

        [JsonPropertyName("id_patient")]
        public int? IdPatient { get; set; }

        [JsonPropertyName("id_facility")]
        public int? IdFacility { get; set; }

        [JsonPropertyName("id_company")]
        public int? IdCompany { get; set; }

        [JsonPropertyName("id_travel_purpose")]
        public int? IdTravelPurpose { get; set; }

        [JsonPropertyName("way_travel")]
        public string? WayTravel { get; set; }

        [JsonPropertyName("date_travel")]
        public string? DateTravel { get; set; }

        [JsonPropertyName("distance")]
        public int? Distance { get; set; }

        [JsonPropertyName("duration")]
        public int? Duration { get; set; }
    }
}
