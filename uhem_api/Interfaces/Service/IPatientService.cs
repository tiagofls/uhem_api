using uhem_api.Dto;

namespace uhem_api.Interfaces.Service
{
    public interface IPatientService
    {
        Task<PatientDto> GetBySns(string sns);
    }
}