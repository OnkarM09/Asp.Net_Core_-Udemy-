using ServiceContracts;

namespace Services
{
    public class Persons : IPersons
    {
        private List<string> _persons;
        private Guid _personGuid;

        public Guid guid { 
            get
            {
                return _personGuid;
            }
        }
        public Persons()
        {
            _personGuid = Guid.NewGuid();
            _persons = new List<string>()
            {
                "John",
                "Dan",
                "Steve",
                "Marcus"
            };
        }
        public List<string> GetPersons()
        {
            return _persons;
        }
    }
}