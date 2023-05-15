using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using MySqlConnector;
using System.Reflection.Emit;
using uhem_api.Dto;

namespace uhem_api.Mappers
{
    public class HealthFacilityMapper
    {
        public static List<HealthFacilityDto> MapManyToHealthFacilityDto(MySqlDataReader data)
        {
            List<HealthFacilityDto> l = new List<HealthFacilityDto>();

            while (data.Read())
            {
                HealthFacilityDto t = new HealthFacilityDto
                {
                    Address = data.GetString("address"),
                    ZipCode = data.GetString("zipcode"),
                    Phone = data.GetString("phone"),
                    Name = data.GetString("name"),
                    Email = data.GetString("email")
                };

                l.Add(t);
            }

            return l;
        }

        public static HealthFacilityDto MapToHealthFacilityDto(MySqlDataReader data)
        {
            HealthFacilityDto t = new HealthFacilityDto();

            if (data.Read())
            {
                t.Address = data.GetString("address");
                t.ZipCode = data.GetString("zipcode");
                t.Phone = data.GetString("phone");
                t.Name = data.GetString("name");
                t.Email = data.GetString("email");
            }

            return t;
        }
    }
}
