using HMS.DAL.Dtos.Requests;
using HMS.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
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


        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] LoginDto loginDto)
        {
            if (!await _authService.UserLogin(loginDto))
                return Unauthorized();
            return Ok(new
            {
                Token = await _authService.GenerateToken()
            });
        }


        [Authorize]
        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto model)
        {
            await _authService.ChangePasswordAsync(model.Email, model.OldPassword, model.NewPassword);
            return Ok();
        }

        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _authService.Logout();

            return Ok();
        }

    }
}
