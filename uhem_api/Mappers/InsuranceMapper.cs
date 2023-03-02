using MySqlConnector;
using uhem_api.Dto;

namespace uhem_api.Mappers
{
    public class InsuranceMapper
    {
        public static List<InsuranceDto> MapManyToInsuranceDto(MySqlDataReader data)
        {
            List<InsuranceDto> l = new List<InsuranceDto>();

            while (data.Read())
            {
                InsuranceDto t = new InsuranceDto
                {
                    EmailInsurance = data.GetString("email_insurance"),
                    IdInsurance = data.GetInt32("id_insurance"),
                    PhoneInsurance = data.GetString("phone_insurance"),
                    NameInsurance = data.GetString("name_insurance")
                };

                l.Add(t);
            }

            return l;
        }

        public static InsuranceDto MapToInsuranceDto(MySqlDataReader data)
        {
            InsuranceDto t = new InsuranceDto();

            while (data.Read())
            {
                
                {
                    t.EmailInsurance = data.GetString("email_insurance");
                    t.IdInsurance = data.GetInt32("id_insurance");
                    t.PhoneInsurance = data.GetString("phone_insurance");
                    t.NameInsurance = data.GetString("name_insurance");
                };
            }

            return t;
        }
    }
}
