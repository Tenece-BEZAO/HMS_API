using HMS.BLL.ActionFilters;
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
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [SwaggerOperation(Summary = "Creates user")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "UserId of created user pls confirm your email", Type = typeof(AuthStatus))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "User with provided email already exists", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Failed to create user", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "It's not you, it's us", Type = typeof(ErrorResponse))]


        public async Task<IActionResult> RegisterUser([FromBody] RegisterDto register)
        {
            var result = await _authService.RegisterUser(register);
            return (IActionResult)result;

        }


        [HttpGet("Email", Name = "confirm-email")]
        [SwaggerOperation(Summary = "Confirm User Email")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Your Email has been verified", Type = typeof(AuthStatus))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Invalid Email address", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "It's not you, it's us", Type = typeof(ErrorResponse))]

        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            await _authService.ConfirmedEmailAsync(token, email);
            return Ok("Your Email has been verified");
        }


        [AllowAnonymous]
        [HttpPost("login", Name = "Login")]
        [SwaggerOperation(Summary = "Authenticates user")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "check your mail for otp", Type = typeof(AuthStatus))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Invalid username or password", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "It's not you, it's us", Type = typeof(ErrorResponse))]

        public async Task<IActionResult> Authenticate([FromBody] LoginDto loginDto)
        {
            AuthStatus response = await _authService.UserLogin(loginDto);

            return Ok(response);
        }


        [HttpPost]
        [Route("login-2FA")]
        [SwaggerOperation(Summary = "Two factor Authentication")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Login Successfull", Type = typeof(AuthStatus))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Invalid username or password", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "It's not you, it's us", Type = typeof(ErrorResponse))]

        public async Task<IActionResult> LoginWithOtp(string userName, string code)
        {
            var token = await _authService.LoginWithOtp(userName, code);
            return Ok(token);
        }


        [Authorize]
        [HttpPost]
        [Route("change-password")]
        [SwaggerOperation(Summary = "Change user password")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Password reset successful", Type = typeof(AuthStatus))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Invalid token or email address", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "Internal server error", Type = typeof(ErrorResponse))]

        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto model)
        {
            var response = await _authService.ChangePasswordAsync(model.Email, model.CurrentPassword, model.NewPassword);
            return Ok(response);
        }



        [AllowAnonymous]
        [HttpGet]
        [Route("ResetPassword")]
        [SwaggerOperation(Summary = "Reset user password")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "link has been sent to your email", Type = typeof(AuthStatus))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Invalid token or email address", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "Internal server error", Type = typeof(ErrorResponse))]
        public async Task<IActionResult> ResetPassword(string token, string email)
        {
            var response = await _authService.ResetPasswordAsync(token, email);
            return Ok(response);
        }



        [AllowAnonymous]
        [HttpPost]
        [Route("forget-password")]
        [SwaggerOperation(Summary = "Sends password reset instructions to user's email")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Password reset instructions sent successfully", Type = typeof(AuthStatus))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Failed to send password reset instructions", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "It's not you, it's us", Type = typeof(ErrorResponse))]

        public async Task<IActionResult> ForgetPassword([Required] string email)
        {
            var response = await _authService.ForgetPasswordAsync(email);
            return Ok(response);
        }



        [AllowAnonymous]
        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest reset)
        {
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
            var result = await _userService.GetUserProfile();
            return Ok(result);
        }
    }
}
