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


        [HttpGet("GetEnrollees")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<EnrolleeDTO>))]
        public async Task<IActionResult> GetEnrollees()
        {
            var enrollees = await _enrolleeService.GetEnrolleesAsync();

            return Ok(enrollees);
        }


        [HttpGet("GetEnrollee/{id}")]
        [ProducesResponseType(200, Type = typeof(EnrolleeDTO))]
        public async Task<ActionResult<EnrolleeDTO>> GetEnrollee(int id)
        {
            var enrollee = await _enrolleeService.GetEnrolleeAsync(id);

            if (enrollee == null)
                return NotFound("Enrollee does not exist");

            return Ok(enrollee);
        }


        [HttpDelete("DeleteEnrollee/{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DeleteEnrollee(int id)
        {
            try
            {
                await _enrolleeService.DeleteEnrolleeAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
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
