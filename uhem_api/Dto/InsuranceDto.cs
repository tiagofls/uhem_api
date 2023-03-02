using System.Text.Json.Serialization;

namespace uhem_api.Dto
{
    public class InsuranceDto
    {

        [JsonPropertyName("id_insurance")]
        public int IdInsurance { get; set; }

        [JsonPropertyName("name_insurance")]
        public string NameInsurance { get; set; }

        [JsonPropertyName("email_insurance")]
        public string EmailInsurance { get; set; }

        [JsonPropertyName("phone_insurance")]
        public string PhoneInsurance { get; set; }
    }
}
