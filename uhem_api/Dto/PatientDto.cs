using System.Text.Json.Serialization;

namespace uhem_api.Dto
{
    public class PatientDto
    {
        [JsonPropertyName("id_patient")]
        public int IdPatient { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("sns")]
        public string Sns { get; set; }

        [JsonPropertyName("birth_date")]
        public string BirthDate { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("zipcode")]
        public string ZipCode { get; set; }

        [JsonPropertyName("id_caregiver")]
        public int IdCaregiver { get; set; }
    }
}
