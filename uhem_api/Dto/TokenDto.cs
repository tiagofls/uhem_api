using System.Text.Json.Serialization;

namespace uhem_api.Dto
{
    public class TokenDto
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }  
        
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("dt_cri")]
        public DateTime Date { get; set; }
    }
}
