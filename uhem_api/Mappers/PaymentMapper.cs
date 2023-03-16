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
                    Paid = data.GetInt32("paid"),
                    Amount = data.GetDouble("amount")
                };

                l.Add(t);
            }

            return l;
        }

        public static PaymentDto MapToPaymentDto(MySqlDataReader data)
        {
            PaymentDto t = new PaymentDto
                {
                    IdPayment = data.GetInt32("id_payment"),
                    Paid = data.GetInt32("paid"),
                    Amount = data.GetDouble("amount")
                };

            return t;
        }
    }
}
