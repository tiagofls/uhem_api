using uhem_api.Dto;

namespace uhem_api.Interfaces.Service
{
    public interface ITravelPurposeService
    {

        Task<List<TravelPurposeDto>> GetAll();

    }
}
