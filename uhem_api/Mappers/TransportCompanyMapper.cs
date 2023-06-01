using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
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
    public class TransportCompanyMapper
    {
        public static List<TransportCompanyDto> MapManyToTransportCompanyDto(MySqlDataReader data)
        {
            List<TransportCompanyDto> l = new List<TransportCompanyDto>();

            while (data.Read())
            {
                TransportCompanyDto t = new TransportCompanyDto
                {
                    Address = data.GetString("address"),
                    Email = data.GetString("email"),
                    IdCompany = data.GetInt32("id_company"),
                    Name = data.GetString("name"),
                    Phone = data.GetString("phone"),
                    ZipCode = data.GetString("zipcode")
                };

                l.Add(t);
            }

            return l;
        }

        public static TransportCompanyDto MapToTransportCompanyDto(MySqlDataReader data)
        {
            TransportCompanyDto t = new TransportCompanyDto();

            if (data.Read())
            {
                t.Address = data.GetString("address");
                t.Email = data.GetString("email");
                t.IdCompany = data.GetInt32("id_company");
                t.Name = data.GetString("name");
                t.Phone = data.GetString("phone");
                t.ZipCode = data.GetString("zipcode");
            }

            return t;
        }
    }
}
