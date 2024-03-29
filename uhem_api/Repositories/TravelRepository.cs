﻿using MySqlConnector;
using System.Net;
using uhem_api.Dto;
using uhem_api.Interfaces.Repository;
using uhem_api.Mappers;

namespace uhem_api.Repositories
{
    public class TravelRepository : ITravelRepository
    {
        public TravelRepository() : base()
        {
        }
        public async Task<List<TravelDto>> GetNextFromSns(MySqlConnection con, string sns)
        {
            try
            {
                await con.OpenAsync();

                DateTime d = DateTime.Now;

                var command = con.CreateCommand();
                command.CommandText = "SELECT * FROM uhem.uhem_travel WHERE date_travel >= @d AND id_patient IN (SELECT id_patient FROM uhem_patient WHERE sns = @sns) ORDER BY date_travel ASC;";
                command.Parameters.AddWithValue("@sns", sns);
                command.Parameters.AddWithValue("@d", d);

                var res = await command.ExecuteReaderAsync();


                return TravelMapper.MapManyToTravelDto(res);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<List<AppointmentDto>> GetNextAppFromSns(MySqlConnection con, string sns)
        {
            try
            {
                await con.OpenAsync();

                DateTime d = DateTime.Now;

                var command = con.CreateCommand();
                command.CommandText = "SELECT * FROM uhem.uhem_appointment WHERE appointment_date >= @d AND sns = @sns ORDER BY appointment_date ASC;";
                command.Parameters.AddWithValue("@sns", sns);
                command.Parameters.AddWithValue("@d", d);

                var res = await command.ExecuteReaderAsync();


                return AppointmentMapper.MapManyToAppointmentDto(res);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<List<AppointmentDto>> GetPreviousAppFromSns(MySqlConnection con, string sns)
        {
            try
            {
                await con.OpenAsync();

                DateTime d = DateTime.Now;

                var command = con.CreateCommand();
                command.CommandText = "SELECT * FROM uhem.uhem_appointment WHERE appointment_date < @d AND sns = @sns ORDER BY appointment_date ASC;";
                command.Parameters.AddWithValue("@sns", sns);
                command.Parameters.AddWithValue("@d", d);

                var res = await command.ExecuteReaderAsync();


                return AppointmentMapper.MapManyToAppointmentDto(res);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<List<TravelDto>> GetPreviousFromSns(MySqlConnection con, string sns)
        {
            try
            {
                await con.OpenAsync();

                var command = con.CreateCommand();
                command.CommandText = "SELECT * FROM uhem.uhem_travel WHERE date_travel < CURRENT_TIMESTAMP AND id_patient IN (SELECT id_patient FROM uhem_patient WHERE sns = @sns) ORDER BY date_travel ASC;";
                command.Parameters.AddWithValue("@sns", sns);

                var res = await command.ExecuteReaderAsync();


                return TravelMapper.MapManyToTravelDto(res);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<bool> SetTravelCall(MySqlConnection con, string id)
        {
            try
            {
                await con.OpenAsync();

                var command = con.CreateCommand();
                command.CommandText = "UPDATE `uhem`.`uhem_appointment` SET `id_travel` = '-1' WHERE (`id_appointment` = @id);";
                command.Parameters.AddWithValue("@id", id);

                var res = await command.ExecuteReaderAsync();


                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}
