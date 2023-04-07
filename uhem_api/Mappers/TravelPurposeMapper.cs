using MySqlConnector;
using System.Reflection.PortableExecutable;
using uhem_api.Dto;

namespace uhem_api.Mappers
{
    public class TravelPurposeMapper
    {
        public static List<TravelPurposeDto> MapManyToTravelPurposeDto(MySqlDataReader data)
        {
            List<TravelPurposeDto> l = new List<TravelPurposeDto>();

            while (data.Read())
            {
                TravelPurposeDto t = new TravelPurposeDto {
                    IdTravelPurpose = data.GetInt32("id_travel_purpose"),
                    Description = data.GetString("description")
                };

                l.Add(t);
            }

            return l;
        }
        public static TravelPurposeDto MapToTravelPurposeDto(MySqlDataReader data)
        {
            TravelPurposeDto t = new TravelPurposeDto();

            if (data.Read())
            {
                t.IdTravelPurpose = data.GetInt32("id_travel_purpose");
                t.Description = data.GetString("description");
            }
            return t;
        }
    }
}
