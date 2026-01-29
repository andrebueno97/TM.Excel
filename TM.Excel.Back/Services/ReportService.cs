using ClosedXML.Excel;
using TM.Excel.Back.Repositories;

namespace TM.Excel.Back.Services
{
    public class ReportService(IPersonRepository personRepository) : IReportService
    {
        private readonly IPersonRepository _personRepository = personRepository;

        public async Task<byte[]?> GenerateExcelReportAsync()
        {
            var pessoas = await _personRepository.GetAllAsync();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Relatório");

                worksheet.Style.Fill.BackgroundColor = XLColor.White;

                worksheet.Cell("B3").Value = "buenotickets";
                worksheet.Range("B3:B4").Merge();

                var logoCell = worksheet.Cell("B3");
                logoCell.Style.Font.Bold = true;
                logoCell.Style.Font.Italic = true;
                logoCell.Style.Font.FontSize = 28;
                logoCell.Style.Font.FontColor = XLColor.BabyBlue;
                logoCell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Bottom;

                worksheet.Cell("B6").Value = "Teste geração arquivo Excel";

                worksheet.Cell("B8").Value = "Data/hora geração";
                worksheet.Cell("C8").Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                // Adicionar cabeçalhos
                worksheet.Cell("B12").Value = "Id";
                worksheet.Cell("C12").Value = "Nome de Usuário";
                worksheet.Cell("D12").Value = "Nome Completo";
                worksheet.Cell("E12").Value = "E-mail";

                // Estilizar cabeçalho
                var headerRange = worksheet.Range("B12:E12");
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Fill.BackgroundColor = XLColor.DarkBlue;
                headerRange.Style.Font.FontColor = XLColor.White;

                // Adicionar dados
                worksheet.Cell("B13").InsertData(pessoas);

                // Auto-ajustar colunas
                worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);

                    return stream.ToArray();
                }
            }
        }
    }
}
