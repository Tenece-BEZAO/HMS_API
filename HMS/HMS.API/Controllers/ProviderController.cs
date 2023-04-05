using HMS.BLL.Implementation;
using HMS.BLL.Interfaces;
using HMS.DAL.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProviderController : Controller
    {
        private readonly IProviderService _providerService;

        public ProviderController(IProviderService providerService)
        {
            _providerService = providerService;
        }


        [HttpGet("getProviders")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProviderDto>))]
        public async Task<IActionResult> GetProviders()
        {
            var providers = await _providerService.GetProvidersAsync();

            return Ok(providers);
        }


        [HttpGet("getProvider/{id}")]
        [ProducesResponseType(200, Type = typeof(ProviderDto))]
        public async Task<ActionResult<ProviderDto>> GetProvider(int id)
        {
            var provider = await _providerService.GetProviderAsync(id);

            if (provider == null)
                return NotFound("Provider does not exist, try again!");

            return Ok(provider);
        }


        [HttpGet("searchProvider")]
        public async Task<IActionResult> SearchProviders(string searchTerm)
        {
            var providers = await _providerService.SearchProvidersAsync(searchTerm);

            if (providers == null)
            {
                return NotFound("No provider found, try again!");
            }
            return Ok(providers);
        }


        [HttpDelete("deactivateProvider/{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DeleteProvider(int id)
        {
            try
            {
                await _providerService.DeleteProviderAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest("Unable to deactivate provider");
            }
        }


        [HttpPost]
        [Route("registerProvider")]
        public async Task<IActionResult> RegisterProvider([FromBody] ProviderDto providerDto)
        {
            if (providerDto == null)
            {
                return BadRequest("Cannot register new provider");
            }

            await _providerService.RegisterProviderAsync(providerDto);

            return Ok(providerDto);
        }
    }
}
