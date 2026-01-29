using TM.Excel.Back.Models;

namespace TM.Excel.Back.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public Task<IEnumerable<Person>> GetAllAsync()
        {
            var pessoas = new List<Person>
            {
                new() { UserName = "joao2026", FullName = "João da Silva", Email = "joaodasilva@zmail.com" },
                new() { UserName = "maria123", FullName = "Maria dos Santos", Email = "maria.santos@coldmail.com" },
                new() { UserName = "pablo007", FullName = "Pablo Souza", Email = "pablo.s.souza@yupii.com" },
                new() { UserName = "andreson.almeida", FullName = "Anderson Almeida", Email = "contato@andersonalmeida.com.br" }
            };

            return Task.FromResult(pessoas.AsEnumerable());
        }
    }
}
