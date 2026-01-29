using TM.Excel.Back.Models;

namespace TM.Excel.Back.Services
{
    public class DataStore : IDataStore
    {
        private List<Person> _people = [];

        public IEnumerable<Person> GetAllPeople() => _people.AsReadOnly();

        public void SetPeople(IEnumerable<Person> people) => _people = people.ToList();
    }
}