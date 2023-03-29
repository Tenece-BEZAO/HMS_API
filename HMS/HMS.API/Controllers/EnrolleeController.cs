using HMS.BLL.Interfaces;
using HMS.DAL.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrolleeController : Controller
    {
        private readonly IEnrolleeService _enrolleeService;

        public EnrolleeController(IEnrolleeService enrolleeService)
        {
            _enrolleeService = enrolleeService;
        }

        [HttpGet]
        [Route("GetEnrollees")]
        public async Task<IActionResult> GetEnrollees()
        {
            var enrollees = await _enrolleeService.GetEnrolleesAsync();

            return Ok(enrollees);
        }


        [HttpPost]
        [Route("AddEnrollee")]
        public async Task<IActionResult> AddEnrollee([FromBody] EnrolleeDTO enrolleeDTO)
        {
            if (enrolleeDTO == null)
            {
                return BadRequest("Cannot create new enrollee");
            }

            await _enrolleeService.NewEnrolleeAsync(enrolleeDTO);

            return Ok(enrolleeDTO);
        }
    }
}
