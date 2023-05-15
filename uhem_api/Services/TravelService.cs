using MySqlConnector;
using uhem_api.Dto;
using uhem_api.Interfaces.Repositories;
using uhem_api.Interfaces.Repository;
using uhem_api.Interfaces.Service;

namespace uhem_api.Services
{
    public class TravelService : ITravelService
    {
        private readonly ITravelRepository _travelRepository;
        private readonly IHealthFacilityRepository _hFacilityRepository;
        private readonly ITravelPurposeRepository _purposeRepository;

        public TravelService(ITravelRepository travelRepository, IHealthFacilityRepository healthFacilityRepository, ITravelPurposeRepository travelPurposeRepository)
        {

            _travelRepository = travelRepository;
            _hFacilityRepository = healthFacilityRepository;
            _purposeRepository = travelPurposeRepository;
            
        }

        public async Task<List<TravelV2Dto>> GetNextFromSns(string sns)
        {
            try
            {
                using (MySqlConnection con = SQLConnection.Connect())
                {
                   var resList = new List<TravelV2Dto>();

                   var travel = await _travelRepository.GetNextFromSns(con, sns);
                    con.CloseAsync();

                    foreach (var t in travel)
                    {
                        var hFacility = await _hFacilityRepository.GetHealthFacilityById(con, (int)t.IdFacility);
                        con.CloseAsync();
                        var purposeT = await _purposeRepository.GetById(con, (int)t.IdTravelPurpose);
                        con.CloseAsync();

                        var tV2 = new TravelV2Dto
                        {
                            Date = t.DateTravel,
                            Duration = t.Duration.ToString(),
                            Facility = hFacility.Name,
                            Purpose = purposeT.Description,
                            Start = GetDatePart(t.DateTravel, 1),
                        };

                        resList.Add(tV2);
                    }

                    return resList;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private string GetDatePart(string date, int part)
        {
            string inputString = "2023-05-15 21:57:46";
            string[] substrings = date.Split(' ');
            
            return substrings[part];
        }

    }
}
