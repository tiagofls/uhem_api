using System.Text.Json.Serialization;

namespace uhem_api.Dto
{
    public class LoginInfoDto
    {
        [JsonPropertyName("username")]
        public string? Username { get; set; }

        [JsonPropertyName("encrypted_password")]
        public string? EncryptedPassword { get; set; }
    }
}
