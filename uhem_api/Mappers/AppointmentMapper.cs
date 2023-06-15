using MySqlConnector;
using System.Net;
using uhem_api.Dto;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace uhem_api.Mappers
{
    public class AppointmentMapper
    {
        public static List<AppointmentDto> MapManyToAppointmentDto(MySqlDataReader data)
        {
            List<AppointmentDto> l = new List<AppointmentDto>();

            while (data.Read())
            {
                AppointmentDto t = new AppointmentDto
                {
                    Appointment = data.GetString("appointment"),
                    Date = data.GetDateTime("appointment_date").ToString(),
                    IdAppointment = data.GetInt32("id_appointment"),
                    Sns = data.GetString("sns"),
                    IdFacility = data.GetInt32("id_facility"),
                    IdTravel = data.GetInt32("id_travel")
                };

                l.Add(t);
            }

            return l;
        }



        public static AppointmentDto MapToAppointmentDto(MySqlDataReader data)
        {
            AppointmentDto t = new AppointmentDto();

            if (data.Read())
            {
                t.Appointment = data.GetString("appointment");
                t.Date = data.GetDateTime("appointment_date").ToString();
                t.IdAppointment = data.GetInt32("id_appointment");
                t.Sns = data.GetString("sns");
                t.IdFacility = data.GetInt32("id_facility");
                t.IdTravel = data.GetInt32("id_travel");
            }

            return t;
        }
    }
}
