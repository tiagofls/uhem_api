using MySqlConnector;
using uhem_api.Dto;

namespace uhem_api.Mappers
{
    public class CaregiverMapper
    {
        public static List<CaregiverDto> MapManyToCaregiverDto(MySqlDataReader data)
        {
            List<CaregiverDto> l = new List<CaregiverDto>();

            while (data.Read())
            {
                CaregiverDto t = new CaregiverDto
                {
                    AddressCaregiver = data.GetString("address_caregiver"),
                    EmailCaregiver = data.GetString("email_caregiver"),
                    IdCaregiver = data.GetInt32("id_caregiver"),
                    NameCaregiver = data.GetString("name_caregiver"),
                    PhoneCaregiver = data.GetString("phone_caregiver"),
                    ZipcodeCaregiver = data.GetString("zipcode_caregiver"),
                };

                l.Add(t);
            }

            return l;
        }

        public static CaregiverDto MapToCaregiverDto(MySqlDataReader data)
        {
            CaregiverDto t = new CaregiverDto();

            if (data.Read())
            {
                t.AddressCaregiver = data.GetString("address_caregiver");
                t.EmailCaregiver = data.GetString("email_caregiver");
                t.IdCaregiver = data.GetInt32("id_caregiver");
                t.NameCaregiver = data.GetString("name_caregiver");
                t.PhoneCaregiver = data.GetString("phone_caregiver");
                t.ZipcodeCaregiver = data.GetString("zipcode_caregiver");
            }

            return t;
        }
    }
}
