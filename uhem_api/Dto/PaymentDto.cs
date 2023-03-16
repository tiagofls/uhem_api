using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace uhem_api.Dto
{
    public class PaymentDto
    {
        [JsonPropertyName("id_payment")]
        public int? IdPayment { get; set; }

        [JsonPropertyName("paid")]
        public int? Paid { get; set; }

        [JsonPropertyName("amount")]
        public double? Amount { get; set; }
    }
}
