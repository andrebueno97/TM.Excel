using TM.Excel.Back.Models;
using TM.Excel.Back.Services;

namespace TM.Excel.Back.Repositories
{
    public class PersonRepository(IDataStore dataStore) : IPersonRepository
    {
        private readonly IDataStore _dataStore = dataStore;

        public Task<IEnumerable<Person>> GetAllAsync()
        {
            var pessoas = _dataStore.GetAllPeople();
            return Task.FromResult(pessoas);
        }
    }
}
