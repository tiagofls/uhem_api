using System.Text.Json.Serialization;

namespace uhem_api.Dto
{
    public class SaltDto
    {

        [JsonPropertyName("username")]
        public string? Username { get; set; }
        
        [JsonPropertyName("salt")]
        public string? Salt { get; set; }



    }
}
