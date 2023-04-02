using HMS.BLL.Interfaces;
using HMS.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static HMS.DAL.Dtos.Requests.AuthenticationRequest;

namespace HMS.BLL.Implementation
{
    public class ClaimServices : IClaimServices
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<ClaimServices> _logger;

        public ClaimServices(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, ILogger<ClaimServices> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        public async Task<IdentityResult> GetAllClaimsAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var registeredUser = await _roleManager.FindByNameAsync(user.Email);
            if (registeredUser == null)
            {
                _logger.LogInformation($"the user with the {email} does not exist");
                return IdentityResult.Failed(new IdentityError { Description = "User does not exist" });
            }
            var userClaims = await _roleManager.GetClaimsAsync(registeredUser);
            if (userClaims != null)
            {
                _logger.LogInformation("Successfully");

            }
            return (IdentityResult)userClaims;
        }

            public async Task<IdentityResult> AddClaimsToUserAsync(string Email, string claimName, string claimValue)
            {
                var registeredUser = await _userManager.FindByEmailAsync(Email);
                if (registeredUser == null)
                {
                    _logger.LogInformation($"the user with the {Email} does not exist");
                    return IdentityResult.Failed(new IdentityError { Description = "User does not exist" });
                }
                var userClaims = new Claim(Email, claimName, claimValue);
                var result = await _userManager.AddClaimAsync(registeredUser, userClaims);
            if (result.Succeeded)
                return result;
            else
                return IdentityResult.Failed(new IdentityError {Description = $"unable to add claim to user" });
            }
        
    }
}
