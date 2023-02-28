using System.Text.Json.Serialization;

namespace uhem_api.Dto
{
    public class TravelPurposeDto
    {

        [JsonPropertyName("id_travel_purpose")]
        public int IdTravelPurpose { get; set;}

        
        [JsonPropertyName("description_travel_purpose")]
        public string DescriptionTravelPurpose { get; set; }

    }
}
