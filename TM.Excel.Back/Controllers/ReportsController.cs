using Microsoft.AspNetCore.Mvc;
using TM.Excel.Back.Services;

namespace TM.Excel.Back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public async Task<IActionResult> GenerateReport()
        {
            var reportContent = await _reportService.GenerateExcelReportAsync();

            if (reportContent == null || reportContent.Length == 0)
                return NoContent();

            return File(
                reportContent,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                $"Report_{DateTime.UtcNow:yyyyMMdd_HHmmss}.xlsx"
            );
        }
    }
}
