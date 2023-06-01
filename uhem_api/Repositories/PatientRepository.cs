using MySqlConnector;
using System.Net;
using uhem_api.Dto;
using uhem_api.Interfaces.Repositories;
using uhem_api.Mappers;

namespace uhem_api.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        public PatientRepository() : base() { }

        public async Task<PatientDto> GetBySns(MySqlConnection con, string sns)
        {
            try
            {
                await con.OpenAsync();

                var command = con.CreateCommand();
                command.CommandText = "SELECT * FROM uhem.uhem_patient WHERE sns = @sns;";
                command.Parameters.AddWithValue("@sns", sns);

                var res = await command.ExecuteReaderAsync();

                return PatientMapper.MapToPatientDto(res);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<PatientDto> GetById(MySqlConnection con, int id)
        {
            try
            {
                await con.OpenAsync();

                var command = con.CreateCommand();
                command.CommandText = "SELECT * FROM uhem.uhem_patient WHERE id_patient = @idPatient;";
                command.Parameters.AddWithValue("@idPatient", id);

                var res = await command.ExecuteReaderAsync();

                return PatientMapper.MapToPatientDto(res);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}
