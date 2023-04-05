using HMS.BLL.Interfaces;
using HMS.DAL.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HMS.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PlanController : Controller
    {
        private readonly IPlanService _planService;

        public PlanController(IPlanService planService)
        {
            _planService = planService;
        }


        [HttpGet("getPlans")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PlanDto>))]
        public async Task<IActionResult> GetPlans()
        {
            var plans = await _planService.GetPlansAsync();

            return Ok(plans);
        }


        [HttpGet("getPlan/{id}")]
        [ProducesResponseType(200, Type = typeof(PlanDto))]
        public async Task<ActionResult<PlanDto>> GetPlanById(int id)
        {
            var plan = await _planService.GetPlanByIdAsync(id);

            if (plan == null)
                return NotFound("Plan doesn't exist");

            return plan;
        }


        [HttpGet("GetPlan/{name}")]
        [ProducesResponseType(200, Type = typeof(PlanDto))]
        public async Task<ActionResult<PlanDto>> GetPlanByName(string name)
        {
            var plan = await _planService.GetPlanByNameAsync(name);

            if (plan == null)
                return NotFound("Plan doesn't exist");

            return plan;
        }


        [HttpPost("subscribePlan")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> AddPlan([FromBody] PlanDto planDto)
        {
            if (planDto == null)
                return BadRequest("Subscription to plan failed, try again!.");

            var addedPlan = await _planService.NewPlanAsync(planDto);

            return CreatedAtAction(nameof(GetPlanById), new { id = addedPlan.Id }, addedPlan);
        }


        [HttpPut("updatePlan")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Update(int id, [FromBody] PlanDto planDto)
        {
            try
            {
                var updatedPlan = await _planService.UpdatePlanAsync(id, planDto);

                if (updatedPlan == null)
                    return BadRequest("Failed to update plan");

                return Ok(updatedPlan);
            }
            catch (ArgumentException)
            {
                return BadRequest("Failed to update plan");
            }
        }


        [HttpDelete("DeletePlan/{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _planService.DeletePlanAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
