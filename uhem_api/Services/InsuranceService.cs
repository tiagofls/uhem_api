using MySqlConnector;
using uhem_api.Dto;
using uhem_api.Interfaces.Repository;
using uhem_api.Interfaces.Service;

namespace uhem_api.Services
{
    public class InsuranceService : IInsuranceService
    {
        private readonly IInsuranceRepository _insuranceRepository;
        public InsuranceService(IInsuranceRepository insuranceRepository) { 
            _insuranceRepository = insuranceRepository;
        }

        public async Task<List<InsuranceDto>> GetAll()
        {
            try
            {
                using (MySqlConnection con = SQLConnection.Connect())
                {
                    var res = await _insuranceRepository.GetAll(con);
                    return res;
                }
            }
            catch(Exception ex)
            {
                throw new System.Exception(ex.ToString());
            }
        }

        public async Task<InsuranceDto> GetById(int id)
        {
            try
            {
                using (MySqlConnection con = SQLConnection.Connect())
                {
                    var res = await _insuranceRepository.GetById(con, id);
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.ToString());
            }
        }

        public async Task<InsuranceDto> GetByName(string name)
        {
            try
            {
                using (MySqlConnection con = SQLConnection.Connect())
                {
                    var res = await _insuranceRepository.GetByName(con, name);
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.ToString());
            }
        }

        public async Task<bool> Post(InsuranceDto data)
        {
            try
            {
                using (MySqlConnection con = SQLConnection.Connect())
                {
                    var res = await _insuranceRepository.Post(con, data);
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.ToString());
            }
        }
    }
}
