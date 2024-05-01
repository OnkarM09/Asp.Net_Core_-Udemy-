using _15._EntityFramerworkCore.Models;

namespace _15._EntityFramerworkCore.Services
{
    public interface IPersonService
    {
        Task<List<Person>> GetPersons();

        Task<Person> GetPersonById(int id);
        
        Task AddPersonToDb(Person person);
    }
}
