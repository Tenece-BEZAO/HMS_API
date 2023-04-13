using HMS.BLL.Interfaces;
using HMS.DAL.Dtos.Reponses;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace HMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly IClaimServices _claimServices;

        public ClaimsController(IClaimServices claimServices)
        {
            _claimServices = claimServices;
        }


        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<AuthStatus>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        public async Task<IActionResult> GetAllClaim(string email)
        {
            var clams = await _claimServices.GetAllClaimsAsync(email);
            return Ok(clams);
        }


        [HttpPost]
        [Route("userClaim")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<AuthStatus>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        public async Task<IActionResult> AddClaims(string email, string claimName, string claimValue)
        {
            var claims = await _claimServices.AddClaimsToUserAsync(email, claimName, claimValue);
            return Ok(claims);
        }


    }
}
