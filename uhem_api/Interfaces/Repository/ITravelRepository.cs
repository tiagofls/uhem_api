﻿using MySqlConnector;
using uhem_api.Dto;

namespace uhem_api.Interfaces.Repository
{
    public interface ITravelRepository
    {
        Task<List<TravelDto>> GetNextFromSns(MySqlConnection con, string sns);
        Task<List<TravelDto>> GetPreviousFromSns(MySqlConnection con, string sns);
        Task<List<AppointmentDto>> GetNextAppFromSns(MySqlConnection con, string sns);
        Task<List<AppointmentDto>> GetPreviousAppFromSns(MySqlConnection con, string sns);
        Task<bool> SetTravelCall(MySqlConnection con, string id);
    }
}