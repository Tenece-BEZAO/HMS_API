using HMS.BLL.Interfaces;
using HMS.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

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

        /*        public async Task<IdentityResult> GetAllClaimsAsync(string email, ApplicationRole role)
                {
                    var user = await _userManager.FindByEmailAsync(email);
                    var registeredUser = await _roleManager.FindByNameAsync(role.Name);
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
                }*/


        public async Task<IEnumerable<Claim>> GetAllClaimsAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                _logger.LogInformation($"the user with the {email} does not exist");
                return null;
            }
            var userRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            var role = await _roleManager.FindByNameAsync(userRole);
            var roleClaims = await _roleManager.GetClaimsAsync(role);
            if (roleClaims != null)
            {
                _logger.LogInformation("Successfully retrieved user claims");
            }
            return roleClaims;
        }

        /*    public async Task<IEnumerable<Claim>> GetAllClaimsAsync(string email)
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    _logger.LogInformation($"the user with the {email} does not exist");
                    return null;
                }
                var userClaims = await _userManager.GetClaimsAsync(user);
                if (userClaims != null)
                {
                    _logger.LogInformation("Successfully retrieved user claims");
                }
                return userClaims;
            }
    */

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
                return IdentityResult.Failed(new IdentityError { Description = $"unable to add claim to user" });
        }

        public async Task<IdentityResult> AddClaimToUserAsync(string email, Claim claim)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                _logger.LogInformation($"User with email {email} not found.");
                return IdentityResult.Failed(new IdentityError { Description = $"User with email {email} not found." });
            }

            var role = await _roleManager.FindByIdAsync(user.Id);
            if (role == null)
            {
                _logger.LogInformation($"Role for user with id {email} not found.");
                return IdentityResult.Failed(new IdentityError { Description = $"Role for user with email {email} not found." });
            }

            var result = await _roleManager.AddClaimAsync(role, claim);
            if (result.Succeeded)
            {
                _logger.LogInformation($"Claim '{claim.Type}' added to user with email {email}.");
            }
            else
            {
                _logger.LogInformation($"Failed to add claim '{claim.Type}' to user with id {email}.");
            }

            return result;
        }



    }
}
