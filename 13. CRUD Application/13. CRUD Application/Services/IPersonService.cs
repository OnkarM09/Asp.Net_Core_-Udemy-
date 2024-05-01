using _13._CRUD_Application.Models;

namespace _13._CRUD_Application.Services
{
    public interface IPersonService
    {
        List<Person> GetPersons();

        Person GetPersonById(int id);

        void UpdatePerson(Person person);
    }
}
