
using HMS.DAL.Dtos.Requests;

namespace HMS.BLL.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<ReportDto>> GetReportsAsync();
        Task<ReportDto> AddReportAsync(ReportDto reportDto);
        Task<IEnumerable<ReportDto>> SearchReportsAsync(string searchTerm);
        Task DeleteReportAsync(int reportId);
    }
}
