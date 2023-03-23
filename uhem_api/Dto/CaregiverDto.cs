using System.Text.Json.Serialization;

namespace uhem_api.Dto
{
    public class CaregiverDto
    {
        [JsonPropertyName("id_caregiver")]
        public int? IdCaregiver { get; set; }

        [JsonPropertyName("name_caregiver")]
        public string? NameCaregiver { get; set; }

        [JsonPropertyName("email_caregiver")]
        public string? EmailCaregiver { get; set; }

        [JsonPropertyName("phone_caregiver")]
        public string? PhoneCaregiver { get; set; }

        [JsonPropertyName("address_caregiver")]
        public string? AddressCaregiver { get; set; }

        [JsonPropertyName("zipcode_caregiver")]
        public string? ZipcodeCaregiver { get; set; }
    }
}
