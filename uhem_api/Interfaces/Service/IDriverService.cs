using uhem_api.Dto;

namespace uhem_api.Interfaces.Service
{
    public interface IDriverService
    {
        Task<DriverDto> GetById(string id);
    }
}
