using AutoMapper;
using HMS.DAL.Dtos.Reponses;
using HMS.DAL.Dtos.Requests;
using HMS.DAL.Entities;
using HMS.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace HMS.BLL.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<AppUser> _signInManager;
        private AppUser? _user;


        public AuthenticationService(IMapper mapper, UserManager<AppUser> userManager, IConfiguration configuration, SignInManager<AppUser> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterUser(RegisterDto register)
        {
            _user = await _userManager.FindByEmailAsync(register.Email);
            if (_user != null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User already exist" });
            }
            var newUser = _mapper.Map(register, _user);
            var result = await _userManager.CreateAsync(newUser, register.Password);
            if (result.Succeeded)
                await _userManager.AddToRolesAsync(newUser, register.Roles);
            return result;
        }

        public async Task<AuthStatus> UserLogin(LoginDto loginDto)
        {
            LoginStatus loginStatus;
            //string jwtToken = "";
            string roleName = "";
            _user = await _userManager.FindByEmailAsync(loginDto.Email);
            var result = _signInManager.PasswordSignInAsync(loginDto.Email,loginDto.Password, false, lockoutOnFailure: true).Result;
            //var result = (_user != null && await _userManager.CheckPasswordAsync(_user, loginDto.Password));
            if (!result.Succeeded)
            {
                loginStatus = LoginStatus.LoginFailed;               
            }
            loginStatus = LoginStatus.LoginSuccessful;

            var authResponse = new AuthStatus()
            {
                LoginStatus = loginStatus,
               // Token = jwtToken,
                Role = roleName
            };
            return authResponse;
        }
        public async Task<string> GenerateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        }
        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfig:Secret").Value);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
             {
             new Claim(ClaimTypes.Name, _user.UserName)
             };
            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
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

    }
}

