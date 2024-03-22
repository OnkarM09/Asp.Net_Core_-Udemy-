namespace Services;
using ServiceContracts;

public class CitiesService : ICitiesService , IDisposable
{
    private List<string> _cities;
    private Guid _serviceInstanceId;
    public Guid ServiceInstanceId
    {
        get
        {
            return _serviceInstanceId;
        }
    }
    public CitiesService()
    {
        _serviceInstanceId = Guid.NewGuid();
        _cities = new List<string>(){
            "London",
            "Mumbai",
            "Tokyo",
            "New York"
        };
        //Constructor to open dp connection
    }

    public List<string> GetCities()
    {
        return _cities;
    }

    public void Dispose()
    {
       //Dispose to close dp connection
    }
}