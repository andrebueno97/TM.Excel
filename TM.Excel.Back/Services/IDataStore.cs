using TM.Excel.Back.Models;

namespace TM.Excel.Back.Services
{
    public interface IDataStore
    {
        IEnumerable<Person> GetAllPeople();
        void SetPeople(IEnumerable<Person> people);
    }
}