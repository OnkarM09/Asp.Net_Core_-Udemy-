using _15._EntityFramerworkCore.Models;
using Microsoft.EntityFrameworkCore;

namespace _15._EntityFramerworkCore.Services
{
    public class PersonService : IPersonService
    {
        private readonly PersonsDbContext _db;

        public PersonService(PersonsDbContext personsDbContext)
        {
            _db = personsDbContext;
        }
        public async Task<List<Person>> GetPersons()
        {
            //SELECT * FROM Persons
            var persons = _db.Persons.Include("JobDetails").ToList();
            return await _db.Persons.ToListAsync();
          //  return _db._spGetAllPersons();   //Calling SP from PersonDbContext
        }

        public async Task<Person?> GetPersonById(int id)
        {
            Person? person = await _db.Persons.Where(person => person.Id == id).FirstOrDefaultAsync();
            return person;
        }
        public async Task AddPersonToDb(Person person)
        {
            _db.Persons.Add(person);
            await _db.SaveChangesAsync();
            //_db.sp_InsertPerson(person);  from stored procedure
        }
    }
}
