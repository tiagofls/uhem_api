using MySqlConnector;
using System.Net;
using System.Numerics;
using System.Reflection.Emit;
using System.Xml.Linq;
using uhem_api.Dto;

namespace uhem_api.Mappers
{
    public class PatientMapper
    {
        public static List<PatientDto> MapManyToPatientDto(MySqlDataReader data)
        {
            List<PatientDto> l = new List<PatientDto>();

            while (data.Read())
            {
                PatientDto t = new PatientDto
                {
                    IdPatient = data.GetInt32("id_patient"),
                    Address = data.GetString("address"),
                    Email = data.GetString("email"),
                    IdCaregiver = data.GetInt32("id_caregiver"),
                    Name = data.GetString("name"),
                    Phone = data.GetString("phone"),
                    Sns = data.GetString("sns"),
                    ZipCode = data.GetString("zipcode"),
                    BirthDate = data.GetString("birth_date")
                };

                l.Add(t);
            }

            return l;
        }

        public static PatientDto MapToPatientDto(MySqlDataReader data)
        {
            PatientDto t = new PatientDto();

            if (data.Read())
            {
                t.IdPatient = data.GetInt32("id_patient");
                t.Address = data.GetString("address");
                t.Email = data.GetString("email");
                t.IdCaregiver = data.GetInt32("id_caregiver");
                t.Name = data.GetString("name");
                t.Phone = data.GetString("phone");
                t.Sns = data.GetString("sns");
                t.ZipCode = data.GetString("zipcode");
                t.BirthDate = data.GetString("birth_date");
            }

            return t;
        }
    }
}
