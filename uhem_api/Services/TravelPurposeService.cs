using MySqlConnector;
using uhem_api.Dto;
using uhem_api.Interfaces.Repositories;
using uhem_api.Interfaces.Service;

namespace uhem_api.Services
{
    public class TravelPurposeService : ITravelPurposeService
    {
        private readonly ITravelPurposeRepository _travelPurposeRepository;

        public TravelPurposeService(ITravelPurposeRepository travelPurposeRepository) {

            _travelPurposeRepository = travelPurposeRepository;
        }

        public async Task<List<TravelPurposeDto>> GetAll()
        {
            try
            {
                using (MySqlConnection con = SQLConnection.Connect())
                {
                    var res = await _travelPurposeRepository.GetAll(con);
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<TravelPurposeDto> GetById(int id)
        {
            try
            {
                using (MySqlConnection con = SQLConnection.Connect())
                {
                    var res = await _travelPurposeRepository.GetById(con, id);
                    return res;
                }
            }
            catch (Exception e)
            {
                throw new System.Exception(e.ToString());
            }
        }

        public async Task<bool> Post(TravelPurposeDto data)
        {
            try
            {
                using (MySqlConnection con = SQLConnection.Connect())
                {
                    var res = await _travelPurposeRepository.Post(con, data);
                    return res;
                }
            }
            catch (Exception e)
            {
                throw new System.Exception(e.ToString());
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                using (MySqlConnection con = SQLConnection.Connect())
                {
                    var res = await _travelPurposeRepository.Delete(con, id);
                    return res;
                }
            }
            catch (Exception e)
            {
                throw new System.Exception(e.ToString());
            }
        }

    }
}
