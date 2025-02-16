using _16.ContactsManger.Core.Domain.Entities;
using _16.ContactsManger.Core.Domain.RepositoryContracts;
using ServiceContracts;

namespace Services
{
    public class PersonAdderService : IPersonAdderService
    {
        private readonly IPersonRepository _personRepository;

        public PersonAdderService(IPersonRepository personRepo)
        {
            _personRepository = personRepo;
        }
        public virtual async Task AddPersonToDb(Person person)
        {
           _personRepository?.AddPerson(person);
        }
    }
}
