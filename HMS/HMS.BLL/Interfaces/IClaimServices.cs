using Microsoft.AspNetCore.Identity;
using System.Security.Claims;


namespace HMS.BLL.Interfaces
{
    public interface IClaimServices
<<<<<<< HEAD
    { 
=======
    {
>>>>>>> 4075c8a4cb9c3a57c974d7e939efee611ca98ea4
        Task<IdentityResult> AddClaimsToUserAsync(string Email, string claimName, string claimValue);
        Task<IEnumerable<Claim>> GetAllClaimsAsync(string email);
        Task<IdentityResult> AddClaimToUserAsync(string email, Claim claim);
    }
}
