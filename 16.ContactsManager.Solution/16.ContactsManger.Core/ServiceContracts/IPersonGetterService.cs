using _16.ContactsManger.Core.Domain.Entities;

namespace ServiceContracts
{
    public interface IPersonGetterService
    {
        Task<List<Person>> GetPersons();

        Task<Person> GetPersonById(int id);
    }
}
