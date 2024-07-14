using _15._EntityFramerworkCore.Models;

namespace _15._EntityFramerworkCore.Services
{
    public class PersonsAdderServiceChild : PersonAdderService
    {
        private readonly PersonsDbContext _db;
        public PersonsAdderServiceChild(PersonsDbContext db) : base(db)
        {
            _db = db;
        }

        public override async Task AddPersonToDb(Person person)
        {
            _db.sp_InsertPerson(person);  //from stored procedure
            await _db.SaveChangesAsync();
        }
    }
}
