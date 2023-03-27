using HMS.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HMS.DAL.Dtos.Requests.AuthenticationRequest;

namespace HMS.BLL.Interfaces
{
    public interface IAdminService
    {
        Task<bool> CreateRoleAsync(IdentityRole role);
        Task<List<ApplicationRole>> GetRolesAsync();
        Task<List<AppUser>> GetUsersAsync();
        Task<bool> AssignRoleToUserAsync(UserRole user);
        Task<bool> RegisterUserAsync(RegisterDto register);
    }
}
