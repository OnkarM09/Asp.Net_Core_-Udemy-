using _15._EntityFramerworkCore.Models;

namespace _15._EntityFramerworkCore.Services
{
    public interface IPersonAdderService
    {
        Task AddPersonToDb(Person person);
    }
}
