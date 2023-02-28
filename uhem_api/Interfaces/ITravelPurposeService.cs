using uhem_api.Dto;

namespace uhem_api.Interfaces
{
    public interface ITravelPurposeService
    {

        Task<List<TravelPurposeDto>> GetAll();

    }
}
