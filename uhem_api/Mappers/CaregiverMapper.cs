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
                    Address = data.GetString("address"),
                    Email = data.GetString("email"),
                    IdCaregiver = data.GetInt32("id_caregiver"),
                    Name = data.GetString("name"),
                    Phone = data.GetString("phone"),
                    Zipcode = data.GetString("zipcode"),
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
                t.Address = data.GetString("address");
                t.Email = data.GetString("email");
                t.IdCaregiver = data.GetInt32("id_caregiver");
                t.Name = data.GetString("name");
                t.Phone = data.GetString("phone");
                t.Zipcode = data.GetString("zipcode");
            }

            return t;
        }
    }
}
