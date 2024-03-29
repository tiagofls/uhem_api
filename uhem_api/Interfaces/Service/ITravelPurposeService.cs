﻿using uhem_api.Dto;

namespace uhem_api.Interfaces.Service
{
    public interface ITravelPurposeService
    {
        Task<List<TravelPurposeDto>> GetAll();
        Task<TravelPurposeDto> GetById(int id);
        Task<string> GetNameById(int id);
        Task<bool> Post(TravelPurposeDto data);
        Task<bool> Delete(int id);
    }
}
