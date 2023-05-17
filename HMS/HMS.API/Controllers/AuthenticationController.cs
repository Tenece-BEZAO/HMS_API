using HMS.BLL.ActionFilters;
using HMS.BLL.Interfaces;
using HMS.DAL.Dtos.Reponses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static HMS.DAL.Dtos.Requests.AuthenticationRequest;

namespace HMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationServices _authService;
        private readonly IUserService _userService;

        public AuthenticationController(IAuthenticationServices authenticationService, IUserService userService)
        {
            _authService = authenticationService;
            _userService = userService;
        }


        [Route("register")]
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [SwaggerOperation(Summary = "Creates user")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "UserId of created user pls confirm your email", Type = typeof(RegistrationResponseDto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "User with provided email already exists", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Failed to create user", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "It's not you, it's us", Type = typeof(ErrorResponse))]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterDto register)
        {
            var result = await _authService.RegisterUser(register);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                return BadRequest(new RegistrationResponseDto { Errors = errors });
            }
            return StatusCode(201, new RegistrationResponseDto { IsSuccessfulRegistration = true, Message = "check your mail for authentication" });
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
        [SwaggerResponse(StatusCodes.Status200OK, Description = "check your mail for otp", Type = typeof(AuthResponseDto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Invalid username or password", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "It's not you, it's us", Type = typeof(ErrorResponse))]

        public async Task<IActionResult> Authenticate([FromBody] LoginDto loginDto)
        {
            AuthResponseDto response = await _authService.UserLogin(loginDto);
            //var response = await _authService.UserLogin(loginDto);
            if (response.IsAuthSuccessful)
                return Ok(response);

            else return BadRequest(response);
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

        [HttpPost("TwoStepVerification")]
        public async Task<IActionResult> TwoStepVerification([FromBody] TwoFactorDto twoFactorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var token = await _authService.VerifyTwoFactorAuth(twoFactorDto);

            return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token });
        }
        [HttpPost("enabletwofactor")]
        public async Task<IActionResult> Enable2Factor(string userId)
        {
            var response = _authService.EnableTwoFactorAuth(userId);
            return Ok(response);
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("forget-password")]
        [SwaggerOperation(Summary = "Sends password reset instructions to user's email")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Password reset instructions sent successfully", Type = typeof(AuthStatus))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Failed to send password reset instructions", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "It's not you, it's us", Type = typeof(ErrorResponse))]

        public async Task<IActionResult> ForgotPassword([Required] string email)
        {
            var response = await _authService.ForgetPasswordAsync(email);
            return Ok(response);
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
        [Route("reset-password")]
        public async Task<IActionResult> ResetPassword(string token, string email)
        {
            var response = await _authService.ResetPasswordAsync(token, email);
            return Ok(response);
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("reset-password")]
        [SwaggerOperation(Summary = "Reset-user-password")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "link has been sent to your email", Type = typeof(AuthStatus))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Invalid token or email address", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "Internal server error", Type = typeof(ErrorResponse))]
        public async Task<IActionResult> ResetPasswordss(ResetPasswordRequest reset)
        {
            var response = await _authService.ResetPasswordAsync(reset);
            return Ok(response);
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


        [HttpPost("google")]
        public async Task<IActionResult> LoginWithGoogle(GoogleAuthDto googleAuth)
        {
            var token = await _authService.GoogleLogin(googleAuth);
            if (token == null)
            {
                return BadRequest();
            }
            return Ok(token);

        }

    }
}
