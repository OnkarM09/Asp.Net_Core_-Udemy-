using _16.ContactsManger.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.ContactsManger.Core.Domain.RepositoryContracts
{
    /// <summary>
    /// Represents data access loginc for managing person entity
    /// </summary>
    public interface IPersonRepository
    {
        /// <summary>
        /// Adds a person into the database
        /// </summary>
        /// <param name="person">Person object to add</param>
        /// <returns>Returns the person object after adding it to the data store</returns>
        Task<Person> AddPerson(Person person);
        Task<List<Person>> GetAllPersons();
        Task<Person?> GetPersonById(int id);
    }
}
