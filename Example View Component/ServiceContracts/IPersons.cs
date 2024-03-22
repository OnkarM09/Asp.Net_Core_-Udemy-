namespace ServiceContracts
{
    public interface IPersons
    {
        public Guid guid { get; }
        public List<string> GetPersons();
    }
}