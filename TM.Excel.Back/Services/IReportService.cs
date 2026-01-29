namespace TM.Excel.Back.Services
{
    public interface IReportService
    {
        Task<byte[]?> GenerateExcelReportAsync();
    }
}
