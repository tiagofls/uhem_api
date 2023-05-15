using DocumentFormat.OpenXml.Wordprocessing;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace uhem_api.Dto
{
    public class HealthFacilityDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("zipcode")]
        public string ZipCode { get; set; }    
    }
}
