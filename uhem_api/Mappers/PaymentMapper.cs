using MySqlConnector;
using uhem_api.Dto;

namespace uhem_api.Mappers
{
    public class PaymentMapper
    {
        public static List<PaymentDto> MapManyToPaymentDto(MySqlDataReader data)
        {
            List<PaymentDto> l = new List<PaymentDto>();

            while (data.Read())
            {
                PaymentDto t = new PaymentDto
                {
                    IdPayment = data.GetInt32("id_payment"),
                    InsurancePercent = data.GetInt32("insurance_percent"),
                    Paid = data.GetBoolean("paid"),
                    SocialSecurityPercent = data.GetInt32("social_security_percent")
                };

                l.Add(t);
            }

            return l;
        }
    }
}
