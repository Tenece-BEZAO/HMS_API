using Microsoft.AspNetCore.Identity;
using System.Security.Claims;


namespace HMS.BLL.Interfaces
{
    public interface IClaimServices
    {
        Task<IdentityResult> AddClaimsToUserAsync(string Email, string claimName, string claimValue);
        Task<IEnumerable<Claim>> GetAllClaimsAsync(string email);
        Task<IdentityResult> AddClaimToUserAsync(string email, Claim claim);
    }
}
