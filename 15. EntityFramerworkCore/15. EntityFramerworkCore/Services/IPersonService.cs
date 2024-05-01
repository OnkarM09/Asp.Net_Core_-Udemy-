using _15._EntityFramerworkCore.Models;

namespace _15._EntityFramerworkCore.Services
{
    public interface IPersonService
    {
        Task<List<Person>> GetPersons();

        Task<Person> GetPersonById(int id);
        
        Task AddPersonToDb(Person person);
        /// <summary>
        /// Returns persons as CSV
        /// </summary>
        /// <returns> Returns the memory stream with CSV data</returns>

        Task<MemoryStream> GerPersonCSV();
    }
}
