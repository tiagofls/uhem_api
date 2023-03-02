using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace uhem_api.Dto
{
    public class PaymentDto
    {
        [JsonPropertyName("id_payment")]
        public int IdPayment { get; set; }

        [JsonPropertyName("paid")]
        public bool Paid { get; set; }

        [JsonPropertyName("insurance_percent")]
        public int InsurancePercent { get; set; }

        [JsonPropertyName("social_security_percent")]
        public int SocialSecurityPercent { get; set; }
    }
}
