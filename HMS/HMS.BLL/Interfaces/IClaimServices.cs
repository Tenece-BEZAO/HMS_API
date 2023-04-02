using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BLL.Interfaces
{
    public interface IClaimServices
    {
        Task<IdentityResult> GetAllClaimsAsync(string Email);
        Task<IdentityResult> AddClaimsToUserAsync(string Email, string claimName, string claimValue);
    }
}
