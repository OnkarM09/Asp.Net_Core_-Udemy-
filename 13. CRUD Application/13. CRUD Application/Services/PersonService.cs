using _13._CRUD_Application.Models;
using System.Runtime.CompilerServices;

namespace _13._CRUD_Application.Services
{
    public class PersonService : IPersonService
    {
        private List<Person> _persons = new List<Person>();

        public PersonService() { 
            List<Person> persons = new List<Person>()
            {
                new Person(){
                    Id = 1,
                    Name = "John",
                    Email = "John@example.com",
                    Age = 28,
                    BirthDate = Convert.ToDateTime("26-02-1996"),
                },
                new Person(){
                    Id = 2,
                    Name = "Itachi",
                    Email = "itachi@example.com",
                    Age = 22,
                    BirthDate = Convert.ToDateTime("15-07-2002"),
                },
                new Person(){
                    Id = 3,
                    Name = "Itadori",
                    Email = "itadori@example.com",
                    Age = 20,
                    BirthDate = Convert.ToDateTime("06-11-2004"),
                },
            };
            _persons = persons;
        }
        public List<Person> GetPersons() {
            return _persons;
        }

        public Person GetPersonById(int id)
        {
            Person person = _persons.Where(person => person.Id == id).FirstOrDefault();
            return person;
        }
        
        public void UpdatePerson(Person person)
        {
            _persons.Where(p => p.Id == person.Id).Select(p1 => { p1.Name = person.Name; p1.Id = person.Id; p1.Age = person.Age; p1.BirthDate = person.BirthDate; p1.Email = person.Email; return p1; }).ToList();
        }
    }
}
