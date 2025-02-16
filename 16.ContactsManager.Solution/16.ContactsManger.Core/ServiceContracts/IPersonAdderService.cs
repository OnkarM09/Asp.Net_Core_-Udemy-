using _16.ContactsManger.Core.Domain.Entities;

namespace ServiceContracts
{
    public interface IPersonAdderService
    {
        Task AddPersonToDb(Person person);
    }
}
