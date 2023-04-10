using AutoMapper;
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


        [HttpGet("GetEnrollee/{id}")]
        [ProducesResponseType(200, Type = typeof(EnrolleeDto))]
        public async Task<ActionResult<EnrolleeDto>> GetEnrollee(int id)
        {
            var enrollee = await _enrolleeService.GetEnrolleeAsync(id);

            if (enrollee == null)
                return NotFound("Enrollee does not exist");

            return Ok(enrollee);
        }



        [HttpGet("GetPlan")]
        [ProducesResponseType(200, Type = typeof(PlanDto))]
        public async Task<ActionResult<PlanDto>> GetEnrolleePlan(int id)
        {
            var enrollee = await _enrolleeService.GetEnrolleeAsync(id);

            if (enrollee == null)
                return NotFound("Enrollee not found");

            var plan = await _enrolleeService.GetEnrolleePlan(id);

            if (plan == null)
                return NotFound("This enrollee currently isn't subscribed to a plan");

            return Ok(plan);
        }





        [HttpPost("NewEnrollee")]
        [ProducesResponseType(200, Type = typeof(EnrolleeDto))]
        public async Task<ActionResult<EnrolleeDto>> CreateEnrollee([FromBody] EnrolleeDto enrolleeDto)
        {
            await _enrolleeService.NewEnrolleeAsync(enrolleeDto);

            return Ok("Enrollee created successfully");
            /*var enrollee = await _enrolleeService.NewEnrolleeAsync(enrolleeDto);

            var createdEnrollee = _mapper.Map<EnrolleeDto>(enrollee);


            var createdEnrolleeDto = _mapper.Map<EnrolleeDto>(enrollee);
            return CreatedAtAction(nameof(CreateEnrollee), new { id = createdEnrollee.Id }, createdEnrolleeDto);*/
        }






        [HttpPost("SetPlan")]
        public async Task<ActionResult> SetEnrolleePlan(int enrolleeId, int planId)
        {
            await _enrolleeService.SetEnrolleePlan(enrolleeId, planId
                );

            return Ok($"Subscribed successfully to plan");
        }




        [HttpPut("Update/{id}")]
        public async Task<ActionResult<EnrolleeDto>> UpdateEnrollee(int id, [FromBody] EnrolleeDto enrolleeDto)
        {
            try
            {
                var updatedEnrollee = await _enrolleeService.UpdateEnrolleeAsync(id, enrolleeDto);

                if (updatedEnrollee == null)
                    return BadRequest("Failed to update enrollee, try again");


                return Ok(updatedEnrollee);
            }
            catch
            {
                return BadRequest("Something went wrong, please try again");
            }

        }


        [HttpDelete("Delete/{id}")]
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
    }
}
