using New_Revision.Models;
using ServiceContracts;

namespace Services
{
   
    public class CityService : ICityService, IDisposable
    {
        private Guid _serviceInstanceId;
        private List<City> _cities;

        public Guid ServiceInstanceId

        {
            get { return _serviceInstanceId; }
        }

        public CityService()
        {
            _cities = new List<City>() {
                new City() { Name = "New York", Population = 8623000 },
                new City() { Name = "Los Angeles", Population = 3990000 },
                new City() { Name = "Chicago", Population = 2716000 },
            };
        }

        public List<City> GetCities()
        {
            return _cities;
        }

        public void Dispose()
        {
            
        }
    }
}
