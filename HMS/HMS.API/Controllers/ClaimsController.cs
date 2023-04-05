using HMS.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetAllClaim(string email)
        {
            var clams = await _claimServices.GetAllClaimsAsync(email);
            return Ok(clams);
        }


        [HttpPost]
<<<<<<< HEAD
=======
        [Route("userClaim")]
        public async Task<IActionResult> AddClaims(string email, string claimName, string claimValue)
        {
            var claims = await _claimServices.AddClaimsToUserAsync(email, claimName, claimValue);
            return Ok(claims);
        }


        [HttpPost]
>>>>>>> 4075c8a4cb9c3a57c974d7e939efee611ca98ea4
        [Route("roleClaim")]
        public async Task<IActionResult> AddClaims(string email, Claim claim)
        {
            var claims = await _claimServices.AddClaimToUserAsync(email, claim);
            return Ok(claims);
        }
    }
}
