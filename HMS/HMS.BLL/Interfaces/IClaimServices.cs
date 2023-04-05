using HMS.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BLL.Interfaces
{
    public interface IClaimServices
    {
        Task<IdentityResult> AddClaimsToUserAsync(string Email, string claimName, string claimValue);
        Task<IEnumerable<Claim>> GetAllClaimsAsync(string email);
        Task<IdentityResult> AddClaimToUserAsync(string email, Claim claim);
    }
}
