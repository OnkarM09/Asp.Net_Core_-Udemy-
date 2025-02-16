using New_Revision.Models;

namespace ServiceContracts
{
    public interface ICityService
    {
        public Guid ServiceInstanceId { get; }
        public List<City> GetCities();
    }
}
