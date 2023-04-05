using HMS.BLL.Interfaces;
using HMS.DAL.Dtos.Reponses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static HMS.DAL.Dtos.Requests.AuthenticationRequest;

namespace HMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authService;
        private readonly IUserService _userService;

        public AuthenticationController(IAuthenticationService authenticationService, IUserService userService)
        {
            _authService = authenticationService;
            _userService = userService;
        }

        [Route("register")]
        [HttpPost]
        [SwaggerOperation(Summary = "Creates user")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "UserId of created user", Type = typeof(AuthStatus))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "User with provided email already exists", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Failed to create user", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "It's not you, it's us", Type = typeof(ErrorResponse))]

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
                return StatusCode(201, "go and confirm your email");
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            await _authService.ConfirmedEmailAsync(token, email);
            return Ok("Email sent Successfully");
        }



        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] LoginDto loginDto)
        {
            AuthStatus response = await _authService.UserLogin(loginDto);

            return Ok(response);
        }
        [HttpPost]
        [Route("login-2FA")]
        public async Task<IActionResult> LoginWithOtp(string userName, string code)
        {
            var token = await _authService.LoginWithOtp(userName, code);
            return Ok(token);
        }

        [Authorize]
        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto model)
        {
            await _authService.ChangePasswordAsync(model.Email, model.CurrentPassword, model.NewPassword);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("ForgotPassword")]
        public async Task<IActionResult> ForgetPassword([Required] string email)
        {
            var response = await _authService.ForgetPasswordAsync(email);
            return Ok(response);
        }


        [AllowAnonymous]
        [HttpGet]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(string token, string email)
        {
            var response = await _authService.ResetPasswordAsync(token, email);
            return Ok(response);
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest reset) {
            var response = await _authService.ResetPasswordAsync(reset);
            return Ok(response);

        }



        [HttpGet]
        [Route("email")]
        public async Task<IActionResult> TestEmail(RegisterDto register)
        {
            await _authService.EmailTestAsync();
           // await _authService.RegisterUser(register);
            return Ok("Email sent Successfully");
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("ForgotPassword")]
        public async Task<IActionResult> ForgetPassword([Required] string email)
        {
            var response = await _authService.ForgetPasswordAsync(email);
            return Ok(response);
        }


        [AllowAnonymous]
        [HttpGet]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(string token, string email)
        {
            var response = await _authService.ResetPasswordAsync(token, email);
            return Ok(response);
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest reset) {
            var response = await _authService.ResetPasswordAsync(reset);
            return Ok(response);
        }



        [HttpGet]
        [Route("email")]
        public async Task<IActionResult> TestEmail(RegisterDto register)
        {
            await _authService.EmailTestAsync();
            return Ok("Email sent Successfully");
        }


      

        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _authService.Logout();
            return Ok();
        }


        [HttpGet, Authorize]
        public async Task<IActionResult> GetUser()
        {
            var result = _userService.GetUserProfile();
            return Ok(result);
        }


       
    }
}
