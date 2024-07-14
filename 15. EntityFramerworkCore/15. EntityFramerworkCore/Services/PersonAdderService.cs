using _15._EntityFramerworkCore.Models;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using OfficeOpenXml;

namespace _15._EntityFramerworkCore.Services
{
    public class PersonAdderService : IPersonAdderService
    {
        private readonly PersonsDbContext _db;

        public PersonAdderService(PersonsDbContext personsDbContext)
        {
            _db = personsDbContext;
        }
        public virtual async Task AddPersonToDb(Person person)
        {
            _db.Persons.Add(person);
            await _db.SaveChangesAsync();
            //_db.sp_InsertPerson(person);  from stored procedure
        }
    }
}
