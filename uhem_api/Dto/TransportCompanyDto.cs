using Newtonsoft.Json;

namespace uhem_api.Dto
{
    public class TransportCompanyDto
    {
        [JsonProperty(PropertyName = "id_company")]
        public int IdCompany { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "zipcode")]
        public string ZipCode { get; set; }
    }
}
