using AutoMapper;
using Google.Apis.Auth;
using HMS.BLL.Interfaces;
using HMS.DAL.Dtos.Reponses;
using HMS.DAL.Dtos.Requests;
using HMS.DAL.Entities;
using HMS.DAL.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using static HMS.DAL.Dtos.Requests.AuthenticationRequest;

namespace HMS.BLL.Implementation
{
    public class AuthenticationService : IAuthenticationServices
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailService _emailService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfigurationSection _goolgeSettings;
        private AppUser? _user;

        public AuthenticationService(
            IMapper mapper,
            UserManager<AppUser> userManager,
            IConfiguration configuration,
            SignInManager<AppUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IEmailService emailService,
            IHttpContextAccessor httpContextAccessor,
            IUrlHelperFactory urlHelperFactory,
            IServiceProvider serviceProvider
            )
        {
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _emailService = emailService;
            _httpContextAccessor = httpContextAccessor;
            _urlHelperFactory = urlHelperFactory;
            _serviceProvider = serviceProvider;
            _goolgeSettings = _configuration.GetSection("GoogleAuthSettings");
        }

        public async Task<IdentityResult> RegisterUser(RegisterDto register)
        {
            _user = await _userManager.FindByEmailAsync(register.Email);
            if (_user != null)
            {
                return IdentityResult.Failed(new IdentityError { Code = "DuplicateEmail", Description = "A user with this email address already exists." });
            }
            var newUser = _mapper.Map<AppUser>(register);
            //  string roles = string.Join(",", register.Roles);
            var nameExist = await _userManager.FindByNameAsync(register.UserName);
            if (nameExist != null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Username already exist" });
            }
            var result = await _userManager.CreateAsync(newUser, register.Password);
            if (!result.Succeeded)
            {
                return IdentityResult.Failed(new IdentityError { Code = "InvalidPassword", Description = "Password must contain alphanumerics, cap and small letter and numbers." });
            }
            // if (await _roleManager.RoleExistsAsync(roles))
            if (newUser.TwoFactorEnabled == true)
            {

                // await _userManager.AddToRolesAsync(newUser, register.Roles);
                string token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);

                var request = _httpContextAccessor.HttpContext.Request;
                var actionContext = new ActionContext(_httpContextAccessor.HttpContext, new Microsoft.AspNetCore.Routing.RouteData(), new ActionDescriptor());

                var urlHelper = _urlHelperFactory.GetUrlHelper(actionContext);
                var assemblyName = "HMS.API";
                var controllerTypeName = "HMS.API.Controllers.AuthenticationController";
                var assembly = Assembly.Load(assemblyName);
                var controllerType = assembly.GetType(controllerTypeName);
                var methodInfo = controllerType.GetMethod("ConfirmEmail");

                var confirmationLink = urlHelper.Action(new UrlActionContext
                {
                    Action = methodInfo.Name,
                    Controller = controllerType.Name.Replace("Controller", ""),
                    Values = new { token, newUser.Email },
                    Protocol = _httpContextAccessor.HttpContext.Request.Scheme,
                    Host = _httpContextAccessor.HttpContext.Request.Host.Value
                });
                var message = new Message(new string[] { newUser.Email }, "confirmation email link", confirmationLink);
                _emailService.sendEmail(message);

                return IdentityResult.Success;
            }
            else
                return IdentityResult.Success;
        }


        public async Task<IdentityResult> EmailTestAsync()
        {
            var message =
                new Message(new string[]
                { "prptamarachi@gmail.com" }, "Test", "<h2>subscribe to my channel<h/2>");
            if (message != null)
            {
                _emailService.sendEmail(message);
                return IdentityResult.Success;
            }
            var error = new IdentityError { Code = "EmailFailed", Description = "Failed to send email." };
            return IdentityResult.Failed(error);

        }

        public async Task<IdentityResult> ConfirmedEmailAsync(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {

                    return IdentityResult.Success;
                }

            }

            var error = new IdentityError { Description = "this user does not exist" };
            return IdentityResult.Failed(error);

        }

        public async Task<string> ForgetPasswordAsync([Required] string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var request = _httpContextAccessor.HttpContext.Request;
                var actionContext = new ActionContext(_httpContextAccessor.HttpContext, new Microsoft.AspNetCore.Routing.RouteData(), new ActionDescriptor());

                var urlHelper = _urlHelperFactory.GetUrlHelper(actionContext);
                var assemblyName = "HMS.API";
                var controllerTypeName = "HMS.API.Controllers.AuthenticationController";
                var assembly = Assembly.Load(assemblyName);
                var controllerType = assembly.GetType(controllerTypeName);
                var methodInfo = controllerType.GetMethod("ResetPassword");

                var forgetPasswordLink = urlHelper.Action(new UrlActionContext
                {
                    Action = methodInfo.Name,
                    Controller = controllerType.Name.Replace("Controller", ""),
                    Values = new { token, user.Email },
                    Protocol = _httpContextAccessor.HttpContext.Request.Scheme,
                    Host = _httpContextAccessor.HttpContext.Request.Host.Value
                });
                var message = new Message(new string[] { user.Email }, "forget password  email link", forgetPasswordLink);
                _emailService.sendEmail(message);
                return "forget password link has been sent to your email; pls verify your email";

            }
            else
            {
                return "email does not exist";
            }
        }

        public async Task<ResetPasswordRequest> ResetPasswordAsync(string token, string email)
        {
            var model = new ResetPasswordRequest()
            {
                Token = token,
                Email = email
            };
            return model;
        }


        public async Task<string> ResetPasswordAsync(ResetPasswordRequest reset)
        {
            var user = await _userManager.FindByEmailAsync(reset.Email);
            if (user != null)
            {
                var passwordRest = await _userManager.ResetPasswordAsync(user, reset.Token, reset.NewPassword);
                if (passwordRest.Succeeded)
                {
                    _mapper.Map(reset, user);
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, reset.NewPassword);
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return "Your Password has Been Changed";
                    }
                }
            }
            // await _userManager.SetLockoutEndDateAsync(user, new DateTime(2000, 1, 1));
            return "email does not exist";
        }



        public async Task<AuthResponseDto> UserLogin(LoginDto loginDto)
        {
            LoginStatus loginStatus;
            _user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (_user == null)
                return new AuthResponseDto { ErrorMessage = "A user with this email address does not exist." };
            /*if (!await _userManager.IsEmailConfirmedAsync(_user))
                return new AuthResponseDto { ErrorMessage = "Email not confirmed" };*/
            var result = (_user != null && await _userManager.CheckPasswordAsync(_user, loginDto.Password));
            await _userManager.AccessFailedAsync(_user);
            if (await _userManager.IsLockedOutAsync(_user))
            {
                var content = $"Your account is locked out. To reset the password click this link: {loginDto.ClientURI}";
                var message = new Message(new string[] { loginDto.Email }, "Locked out account information", content);

                _emailService.sendEmail(message);

                return new AuthResponseDto { ErrorMessage = "Your account has been locked out." };
            }

            /*    if (await _userManager.GetTwoFactorEnabledAsync(user))
                    return await GenerateOTPFor2StepVerification(user);*/

            if (_user.TwoFactorEnabled)
            {
                var providers = await _userManager.GetValidTwoFactorProvidersAsync(_user);
                if (!providers.Contains("Email"))
                {
                    return new AuthResponseDto { ErrorMessage = "Invalid 2-Step Verification Provider." };
                }

                await _signInManager.SignOutAsync();
                await _signInManager.PasswordSignInAsync(_user, loginDto.Password, false, false);
                var token = await _userManager.GenerateTwoFactorTokenAsync(_user, "Email");
                var message = new Message(new string[] { _user.Email }, "OTP confirmation", token);
                _emailService.sendEmail(message);
                var deliver = "check your email for otp";
                return new AuthResponseDto { IsAuthSuccessful = true, Token = deliver, Is2StepVerificationRequired = true, Provider = "Email" };
            }

            var authResponse = new AuthResponseDto()
            {
                IsAuthSuccessful = true,
                Token = await GenerateToken(_user),
            };

            //return Task.FromResult(authResponse);
            return authResponse;
        }

        public async Task<string> LoginWithOtp(string userName, string code)
        {
            _user = await _userManager.FindByNameAsync(userName);
            var signIn = await _signInManager.TwoFactorSignInAsync("Email", code, false, false);

            //if (!signIn.Succeeded)
            if (signIn == null)
            {
                throw new InvalidOperationException("Invalid token");
            }

            return await GenerateToken(_user);
        }


        private async Task<string> GenerateToken(AppUser user)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims(user);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfig:Secret").Value);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims(AppUser _user)
        {
            if (_user == null)
            {
                throw new ArgumentNullException(nameof(_user), "User cannot be null.");
            }

            var claims = new List<Claim>
            {
                 new Claim(JwtRegisteredClaimNames.Sub, _user.Id.ToString()),
                 new Claim(ClaimTypes.Name, _user.UserName),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                 new Claim(ClaimTypes.NameIdentifier, _user.Id.ToString()),

             };
            var userClaims = await _userManager.GetClaimsAsync(_user);
            claims.AddRange(userClaims);

            var roles = await _userManager.GetRolesAsync(_user);

            foreach (var userRole in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
                var role = await _roleManager.FindByNameAsync(userRole);
                if (role != null)
                {
                    var roleClaims = await _roleManager.GetClaimsAsync(role);
                    foreach (var roleClaim in roleClaims)
                    {
                        claims.Add(roleClaim);
                    }
                }
            }
            return claims;
        }



        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtConfig");
            var tokenOptions = new JwtSecurityToken
            (
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["Expires"])),
            signingCredentials: signingCredentials
            );
            return tokenOptions;
        }


        public async Task<IdentityResult> ChangePasswordAsync(string Email, string oldPassword, string newPassword)
        {
            var user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }

            var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            return result;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }


        public async Task<AuthResponseDto> GoogleLogin(GoogleAuthDto googleAuth)
        {
            var payload = await VerifyGoogleToken(googleAuth);
            if (payload == null)
                throw new Exception("Invalid External Authentication.");
            var info = new UserLoginInfo(googleAuth.Provider, payload.Subject, googleAuth.Provider);
            var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(payload.Email);
                if (user == null)
                {
                    user = new AppUser { Email = payload.Email, UserName = payload.Email };
                    await _userManager.CreateAsync(user);
                    //prepare and send an email for the email confirmation
                    await _userManager.AddToRoleAsync(user, "Viewer");
                    await _userManager.AddLoginAsync(user, info);
                }
                else
                {
                    await _userManager.AddLoginAsync(user, info);
                }
            }
            if (user == null)
                throw new Exception("Invalid External Authentication.");
            //check for the Locked out account
            var token = await GenerateToken(user);
            //return token;
            return new AuthResponseDto { Token = token, IsAuthSuccessful = true };
        }
        private async Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(GoogleAuthDto googleAuth)
        {
            try
            {
                var settings = new GoogleJsonWebSignature.ValidationSettings()
                {
                    Audience = new List<string>() { _goolgeSettings.GetSection("clientId").Value }
                };

                var payload = await GoogleJsonWebSignature.ValidateAsync(googleAuth.IdToken, settings);
                return payload;
            }
            catch (Exception ex)
            {
                //log an exception
                return null;
            }
        }
        public async Task<string> VerifyTwoFactorAuth(TwoFactorDto twoFactorDto)
        {

            var user = await _userManager.FindByEmailAsync(twoFactorDto.Email);
            if (user is null)
                return "Invalid Request";
            // await _userManager.SetTwoFactorEnabledAsync(user, true);
            var validVerification = await _userManager.VerifyTwoFactorTokenAsync(user, twoFactorDto.Provider, twoFactorDto.Token);
            if (!validVerification)
                return "Invalid Token Verification";

            var token = await GenerateToken(user);
            return token;
        }

        public async Task EnableTwoFactorAuth(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                await _userManager.SetTwoFactorEnabledAsync(user, true);
            }
        }




    }
}
