using HMS.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
           public async Task<IActionResult> AddClaims(string email, string claimName, string claimValue)
           {
               var claims = await _claimServices.AddClaimsToUserAsync(email, claimName, claimValue);
               return Ok(claims);
           }


        [HttpPost]
        [Route("roleClaim")]
        public async Task<IActionResult> AddClaims(string email, Claim claim)
        {
            var claims = await _claimServices.AddClaimToUserAsync(email, claim);
            return Ok(claims);
        }
    }
}
