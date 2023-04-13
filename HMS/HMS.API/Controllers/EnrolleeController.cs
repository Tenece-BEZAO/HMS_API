using AutoMapper;
using HMS.BLL.Interfaces;
using HMS.DAL.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrolleeController : ControllerBase
    {
        private readonly IEnrolleeService _enrolleeService;
        private readonly IMapper _mapper;

        public EnrolleeController(IEnrolleeService enrolleeService, IMapper mapper)
        {
            _enrolleeService = enrolleeService;
            _mapper = mapper;
        }

        [HttpGet("Enrollees")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<EnrolleeDto>))]
        public async Task<IActionResult> GetEnrollees()
        {
            var enrollees = await _enrolleeService.GetEnrolleesAsync();

            return Ok(enrollees);
        }


        [HttpGet("GetEnrollee/{enrolleeId}")]
        [ProducesResponseType(200, Type = typeof(EnrolleeDto))]
        public async Task<ActionResult<EnrolleeDto>> GetEnrollee(string enrolleeId)
        {
            var enrollee = await _enrolleeService.GetEnrolleeAsync(enrolleeId);

            if (enrollee == null)
                return NotFound("Enrollee does not exist");

            return Ok(enrollee);
        }



        [HttpGet("GetEnrollePlan/{enrolleeId}")]
        [ProducesResponseType(200, Type = typeof(PlanDto))]
        public async Task<ActionResult<PlanDto>> GetEnrolleePlan(string enrolleeId)
        {
            var enrollee = await _enrolleeService.GetEnrolleeAsync(enrolleeId);

            if (enrollee == null)
                return NotFound("Enrollee not found");

            var plan = await _enrolleeService.GetEnrolleePlanAsync(enrolleeId);

            if (plan == null)
                return NotFound("This enrollee currently isn't subscribed to a plan");

            return Ok(plan);
        }


        [HttpPost("RegisterEnrollee")]
        public async Task<IActionResult> AddEnrollee([FromBody] EnrolleeDto enrolleeDto)
        {
            try
            {
                if (enrolleeDto == null)
                {
                    return BadRequest("Cannot create new enrollee");
                }

                await _enrolleeService.CreateEnrolleeAsync(enrolleeDto);

                return Ok(enrolleeDto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }

        }



        [HttpPost("{enrolleeId}/subscribeToPlan")]
        public async Task<ActionResult> SubscribeToPlan(string enrolleeId, int planId)
        {
            try
            {
                await _enrolleeService.SubscribeToPlanAsync(enrolleeId, planId
                );

                return Ok($"Subscribed successfully to plan");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }

        }



        [HttpPut("Update/{id}")]
        public async Task<ActionResult<EnrolleeDto>> UpdateEnrollee(string id, [FromBody] EnrolleeDto enrolleeDto)
        {
            try
            {
                if (enrolleeDto == null)
                    return BadRequest("Cannot update enrollee");

                await _enrolleeService.UpdateEnrolleeAsync(id, enrolleeDto);


                return Ok(enrolleeDto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong, please try again\n\nError: {ex.Message}");
            }

        }



        [HttpPut("{enrolleeId}/unsubscribefromplan")]
        public async Task<IActionResult> UnsubscribeFromPlan(string enrolleeId)
        {
            try
            {
                await _enrolleeService.UnsubscribeFromPlanAsync(enrolleeId);
                return Ok("Unsubscribed from plan");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }




        [HttpDelete("Delete/{enrolleeId}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DeleteEnrollee(string enrolleeId)
        {
            try
            {
                await _enrolleeService.DeleteEnrolleeAsync(enrolleeId);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
