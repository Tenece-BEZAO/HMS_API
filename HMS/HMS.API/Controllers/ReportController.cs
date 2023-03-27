using HMS.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HMS.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }


        [HttpGet]
        [Route("GetReports")]
        public async Task<IActionResult> GetReports()
        {
            var appointments = await _reportService.GetReportsAsync();
            return Ok(appointments);
        }


        [HttpGet("SearchReport/{id}")]
        public async Task<IActionResult> SearchReport(string searchTerm)
        {
            var report = await _reportService.SearchReportsAsync(searchTerm);

            if (report == null)
            {
                return NotFound();
            }
            return Ok(report);
        }


        [HttpDelete("DeleteReport/{id}")]
        public async Task<IActionResult> DeleteReport(int id)
        {
            try
            {
                await _reportService.DeleteReportAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
