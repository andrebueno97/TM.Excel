using TM.Excel.Back.Models;
using TM.Excel.Back.Services;

namespace TM.Excel.Back.Data
{
    public class DataSeeder : IDataSeeder
    {
        private readonly IDataStore _dataStore;

        public DataSeeder(IDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public Task SeedAsync()
        {
            var pessoas = new List<Person>
            {
                new() { UserName = "joao2026", FullName = "João da Silva", Email = "joaodasilva@zmail.com" },
                new() { UserName = "maria123", FullName = "Maria dos Santos", Email = "maria.santos@coldmail.com" },
                new() { UserName = "pablo007", FullName = "Pablo Souza", Email = "pablo.s.souza@yupii.com" },
                new() { UserName = "andreson.almeida", FullName = "Anderson Almeida", Email = "contato@andersonalmeida.com.br" },
                new() { UserName = "gustavomaia88", FullName = "Gustavo Alves Maia", Email = "gus88@zmail.com" }
            };

            _dataStore.SetPeople(pessoas);

            return Task.CompletedTask;
        }
    }
}