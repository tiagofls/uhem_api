using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using MySqlConnector;
using System.Net;
using System.Numerics;
using System.Reflection.Emit;
using System.Xml.Linq;
using uhem_api.Dto;

namespace uhem_api.Mappers
{
    public class DriverMapper
    {
        public static List<DriverDto> MapManyToDriverDto(MySqlDataReader data)
        {
            List<DriverDto> l = new List<DriverDto>();

            while (data.Read())
            {
                DriverDto t = new DriverDto
                {
                    Email = data.GetString("email"),
                    IdCompany = data.GetInt32("id_company"),
                    IdDriver = data.GetInt32("id_driver"),
                    Name = data.GetString("name"),
                    Phone = data.GetString("phone")
                };

                l.Add(t);
            }

            return l;
        }

        public static DriverDto MapToDriverDto(MySqlDataReader data)
        {
            DriverDto t = new DriverDto();

            if (data.Read())
            {
                t.Email = data.GetString("email");
                t.IdCompany = data.GetInt32("id_company");
                t.IdDriver = data.GetInt32("id_driver");
                t.Name = data.GetString("name");
                t.Phone = data.GetString("phone");
            }

            return t;
        }
    }
}
