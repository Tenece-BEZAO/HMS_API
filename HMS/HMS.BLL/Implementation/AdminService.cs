using AutoMapper;
using HMS.BLL.Interfaces;
using HMS.DAL.Dtos.Requests;
using HMS.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NLog;
using static HMS.DAL.Dtos.Requests.AuthenticationRequest;

namespace HMS.BLL.Implementation
{
    public class AdminService : IAdminService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
       

        public AdminService(IConfiguration configuration, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        
        }


        public async Task<bool> CreateRoleAsync(IdentityRole role)
        {
            bool isRoleCreated = false;
            var roleExist = await _roleManager.RoleExistsAsync(role.Name);
            if(!roleExist)
            {
                var res = await _roleManager.CreateAsync(role);
                if (res.Succeeded)
                {
                    isRoleCreated = true;
                }
                return isRoleCreated;
            }
            return isRoleCreated;
      
        }

        
        public async Task<bool> DeleteRoleAsync(IdentityRole role)
        {
            //var roleExist = await _roleManager.RoleExistsAsync(role.Name);

            var _role = await _roleManager.FindByNameAsync(role.Name);
            if (_role != null)
            {
                var res = await _roleManager.DeleteAsync(_role);

                if (!res.Succeeded)
                {
                    throw new ArgumentException("Role can not be deleted.");
                }
                return true;
            }

            return false;
        }


        public async Task<List<ApplicationRole>> GetRolesAsync()
        {
            List<ApplicationRole> roles = new List<ApplicationRole>();
            roles = (from r in await _roleManager.Roles.ToListAsync()
                     select new ApplicationRole()
                     {
                         Name = r.Name,
                     }).ToList();
            return roles;
        }


        public async Task<IEnumerable<AppUserDto>> GetUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var appUserDtos = _mapper.Map<IEnumerable<AppUserDto>>(users);
            return appUserDtos;
        }


        public async Task<bool> AssignRoleToUserAsync(UserRole user)
        {
            bool isRoleAssigned = false;
            var registeredUser = await _userManager.FindByEmailAsync(user.Email);
            if (registeredUser == null)
            {
                return false;
            }
            var role = _roleManager.FindByNameAsync(user.RoleName).Result;
            if (role != null)
            {
                var res = await _userManager.AddToRoleAsync(registeredUser, role.Name);
                if (res.Succeeded)
                {
                    isRoleAssigned = true;
                }
            }
            return isRoleAssigned;
        }


        public async Task<bool> RemoveUserFromRoleAsync(UserRole user)
        {
            bool isRoleAssigned = false;
            var registeredUser = await _userManager.FindByEmailAsync(user.Email);
            if (registeredUser == null)
            {
                return false;
            }
            var role = _roleManager.FindByNameAsync(user.RoleName).Result;
            if (role != null)
            {
                var res = await _userManager.RemoveFromRoleAsync(registeredUser, role.Name);
                if (res.Succeeded)
                {
                    isRoleAssigned = true;
                }
            }
            return isRoleAssigned;
        }


        public async Task<bool> RegisterUserAsync(RegisterDto register)
        {
            bool IsCreated = false;
            AppUser user = await _userManager.FindByEmailAsync(register.Email);
            if (user != null)
            {
                return IsCreated;
            }
            var registerUser = _mapper.Map(register, user);
            var result = await _userManager.CreateAsync(registerUser, register.Password);
            if (result.Succeeded)
            {
                IsCreated = true;
            }
            return IsCreated;
        }
    }
}
