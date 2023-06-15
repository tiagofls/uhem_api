using System.Text.Json.Serialization;

namespace uhem_api.Dto
{
    public class AppointmentDto
    {
        [JsonPropertyName("id_appointment")]
        public int IdAppointment { get; set; }

        [JsonPropertyName("appointment")]
        public string Appointment { get; set;}

        [JsonPropertyName("sns")]
        public string Sns { get; set; }

        [JsonPropertyName("appointment_date")]
        public string Date { get; set; }

        [JsonPropertyName("id_facility")]
        public int IdFacility { get; set; }

        [JsonPropertyName("id_travel")]
        public int IdTravel { get; set; }

    }
}
