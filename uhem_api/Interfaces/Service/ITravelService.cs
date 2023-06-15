using uhem_api.Dto;

namespace uhem_api.Interfaces.Service
{
    public interface ITravelService
    {
        Task<List<TravelV2Dto>> GetNextFromSns(string sns);
        Task<List<TravelV2Dto>> GetPreviousFromSns(string sns);
        Task<List<AppointmentDto>> GetNextAppFromSns(string sns);
        Task<List<AppointmentDto>> GetPreviousAppFromSns(string sns);
        Task<bool> SetTravelCall(string id);
    }
}
