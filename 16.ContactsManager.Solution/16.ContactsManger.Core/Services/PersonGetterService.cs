using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using OfficeOpenXml;
using ServiceContracts;
using _16.ContactsManger.Core.Domain.Entities;
using _16.ContactsManger.Core.Domain.RepositoryContracts;

namespace Services
{
    public class PersonGetterService : IPersonGetterService
    {
        private readonly IPersonRepository _personRepository;

        public PersonGetterService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<List<Person>> GetPersons()
        {
            return await _personRepository.GetAllPersons();
        }

        public async Task<Person?> GetPersonById(int id)
        {
            Person? person = await _personRepository.GetPersonById(id);
            if (person == null)
            {
                throw new InvalidProgramException("Person does not exist");
            }
            return person;
        }
    }
}
