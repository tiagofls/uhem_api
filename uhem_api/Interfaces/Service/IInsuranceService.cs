using uhem_api.Dto;

namespace uhem_api.Interfaces.Service
{
    public interface IInsuranceService
    {
        Task<List<InsuranceDto>> GetAll();
        Task<InsuranceDto> GetById(int id);
        Task<InsuranceDto> GetByName(string name);
        Task<bool> Post(InsuranceDto data);
        Task<bool> Delete(int id);
    }
}
