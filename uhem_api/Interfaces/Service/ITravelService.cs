using uhem_api.Dto;

namespace uhem_api.Interfaces.Service
{
    public interface ITravelService
    {
        Task<List<TravelV2Dto>> GetNextFromSns(string sns);
    }
}
