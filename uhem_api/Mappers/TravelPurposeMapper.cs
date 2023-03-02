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
                    DescriptionTravelPurpose = data.GetString("description_travel_purpose")
                };

                l.Add(t);
            }

            return l;
        }
        public static TravelPurposeDto MapToTravelPurposeDto(MySqlDataReader data)
        {
            TravelPurposeDto t = new TravelPurposeDto();

            while (data.Read())
            {
                t.IdTravelPurpose = data.GetInt32("id_travel_purpose");
                t.DescriptionTravelPurpose = data.GetString("description_travel_purpose");
            }
            return t;
        }
    }
}
