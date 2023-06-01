using uhem_api.Dto;

namespace uhem_api.Interfaces.Service
{
    public interface ITransportCompanyService
    {
        Task<TransportCompanyDto> GetById(string id);
    }
}
