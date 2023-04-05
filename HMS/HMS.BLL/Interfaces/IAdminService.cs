using HMS.DAL.Dtos.Requests;
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
        //Task<bool> CreateRoleAsync(string name);
        Task<List<ApplicationRole>> GetRolesAsync();
        Task<IEnumerable<AppUserDto>> GetUsersAsync();
        Task<bool> AssignRoleToUserAsync(UserRole user);
        Task<bool> RegisterUserAsync(RegisterDto register);
        Task<bool> RemoveUserFromRoleAsync(UserRole user);
        Task<bool> DeleteRoleAsync(IdentityRole role);
    }
}
