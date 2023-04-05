using HMS.BLL.Interfaces;
using HMS.DAL.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrugController : Controller
    {
        private readonly IDrugService _drugService;

        public DrugController(IDrugService appointmentService)
        {
            _drugService = appointmentService;
        }


        [HttpGet("GetDrugs")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PlanDto>))]
        public async Task<IActionResult> GetDrugs()
        {
            var drugs = await _drugService.GetDrugsAsync();

            return Ok(drugs);

        }


        [HttpGet("GetDrug/{id}")]
        [ProducesResponseType(200, Type = typeof(DrugDto))]
        public async Task<ActionResult<DrugDto>> GetDrugById(int id)
        {
            var drug = await _drugService.GetDrugByIdAsync(id);

            if (drug == null)
                return NotFound("Plan doesn't exist");

            return drug;
        }


        [HttpGet("GetDrug/{name}")]
        [ProducesResponseType(200, Type = typeof(DrugDto))]
        public async Task<ActionResult<DrugDto>> GetDrugByName(string name)
        {
            var drug = await _drugService.GetDrugByNameAsync(name);

            if (drug == null)
                return NotFound("Plan doesn't exist");

            return drug;
        }


        [HttpPost("AddDrug")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> AddDrug([FromBody] DrugDto drugDto)
        {
            if (drugDto == null)
                return BadRequest("Drug cannot be created.");

            var addedDrug = await _drugService.NewDrugAsync(drugDto);

            return CreatedAtAction(nameof(GetDrugById), new { id = addedDrug.Id }, addedDrug);
        }


        [HttpPut("UpdateDrug")]
        [ProducesResponseType(200, Type = typeof(DrugDto))]
        public async Task<IActionResult> Update(int id, [FromBody] DrugDto drugDto)
        {
            try
            {
                var updatedDrug = await _drugService.UpdateDrugAsync(id, drugDto);

                if (updatedDrug == null)
                    return BadRequest("Failed to update drug");

                return Ok(updatedDrug);
            }
            catch (ArgumentException)
            {
                return BadRequest("Failed to update drug");
            }
        }


        [HttpDelete("DeleteDrug/{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _drugService.DeletDrugAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
