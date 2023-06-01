using System.Text.Json.Serialization;

namespace uhem_api.Dto
{
    public class DriverDto
    {
        [JsonPropertyName("id_driver")]
        public int IdDriver { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("id_company")]
        public int IdCompany { get; set; }
    }
}
