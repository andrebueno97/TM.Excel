using Microsoft.AspNetCore.Mvc;
using ClosedXML.Excel;

namespace TM.Excel.Back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GenerateReport()
        {
            var report = await GenerateExcel();

            return report;
        }

        private async Task<FileContentResult> GenerateExcel()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Relatório");

                // Adicionar cabeçalhos
                worksheet.Cell("A1").Value = "Id";
                worksheet.Cell("B1").Value = "Nome de Usuário";
                worksheet.Cell("C1").Value = "Nome Completo";
                worksheet.Cell("D1").Value = "E-mail";

                // Estilizar cabeçalho
                var headerRange = worksheet.Range("A1:D1"); 
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Fill.BackgroundColor = XLColor.DarkBlue;
                headerRange.Style.Font.FontColor = XLColor.White;

                // Adicionar com lista de objetos
                var pessoas = new List<Person>
                {
                    new("joao2026", "João da Silva", "joaodasilva@zmail.com"),
                    new("maria123", "Maria dos Santos", "maria.santos@coldmail.com"),
                    new("pablo007", "Pablo Souza", "pablo.s.souza@yupii.com"),
                    new("aaaaa", "Anderson Almeida", "aaaaaaaa@aaaaaaa.com")
                };

                worksheet.Cell("A2").InsertData(pessoas);

                // Auto-ajustar colunas
                worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);

                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        $"Report_{DateTime.UtcNow:yyyyMMdd_HHmmss}.xlsx"
                    );
                }
            }
        }
        private class Person(string userName, string fullName, string Email)
        {
            public Guid Id { get; set; } = Guid.NewGuid();
            public string UserName { get; set; } = userName;
            public string FullName { get; set; } = fullName;
            public string Email { get; set; } = Email;
        }
    }
}
