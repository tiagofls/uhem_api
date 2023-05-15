using MySqlConnector;
using System.Reflection.PortableExecutable;
using uhem_api.Dto;

namespace uhem_api.Mappers
{
    public class TravelMapper
    {
        public static List<TravelDto> MapManyToTravelDto(MySqlDataReader data)
        {
            List<TravelDto> l = new List<TravelDto>();

            while (data.Read())
            {
                TravelDto t = new TravelDto
                {
                    IdTravel = data.GetInt32("id_travel"),
                    DateTravel = data.GetString("date_travel"),
                    Distance = data.GetInt32("distance"),
                    Duration = data.GetInt32("duration"),
                    IdCompany = data.GetInt32("id_company"),
                    IdDriver = data.GetInt32("id_driver"),
                    IdFacility = data.GetInt32("id_facility"),
                    IdPatient = data.GetInt32("id_patient"),
                    IdTravelPurpose = data.GetInt32("id_travel_purpose"),
                    WayTravel = data.GetString("way_travel")
                };

                l.Add(t);
            }

            return l;
        }
        public static TravelDto MapToTravelDto(MySqlDataReader data)
        {
            TravelDto t = new TravelDto();

            if (data.Read())
            {
                t.IdTravel = data.GetInt32("id_travel");
                t.DateTravel = data.GetString("date_travel");
                t.Distance = data.GetInt32("distance");
                t.Duration = data.GetInt32("duration");
                t.IdCompany = data.GetInt32("id_company");
                t.IdDriver = data.GetInt32("id_driver");
                t.IdFacility = data.GetInt32("id_facility");
                t.IdPatient = data.GetInt32("id_patient");
                t.IdTravelPurpose = data.GetInt32("id_travel_purpose");
                t.WayTravel = data.GetString("way_travel");
            }
            return t;
        }
    }
}

