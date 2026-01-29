using TM.Excel.Back.Models;

namespace TM.Excel.Back.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllAsync();
    }
}
