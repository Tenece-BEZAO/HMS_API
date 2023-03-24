using HMS.DAL.Dtos.Requests;
using HMS.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authService = authenticationService;
        }

        [HttpPost]
        [Route("register")]
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterDto register)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.RegisterUser(register);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.TryAddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
                return StatusCode(201);
            }
            return BadRequest();
        }

/*        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                await _authService.UserLogin(loginDto);
                return StatusCode(201);
            }
            return BadRequest();
        }*/
    }
}
