using _15._EntityFramerworkCore.Models;

namespace _15._EntityFramerworkCore.Services
{
    public interface IPersonGetterService
    {
        Task<List<Person>> GetPersons();

        Task<Person> GetPersonById(int id);

        Task<MemoryStream> GerPersonCSV();
        /// <summary>
        /// Returns persons as Excel
        /// </summary>
        /// <returns> Returns the memory stream with Excel data</returns>
        Task<MemoryStream> GerPersonExcel();
    }
}
