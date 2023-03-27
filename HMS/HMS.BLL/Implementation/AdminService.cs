using AutoMapper;
using HMS.BLL.Interfaces;
using HMS.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using static HMS.DAL.Dtos.Requests.AuthenticationRequest;

namespace HMS.BLL.Implementation
{
    public class AdminService : IAdminService
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public AdminService(IConfiguration configuration, SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _configuration = configuration;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<bool> CreateRoleAsync(IdentityRole role)
        {
            bool isRoleCreated = false;
            var res = await _roleManager.CreateAsync(role);
            if (res.Succeeded)
            {
                isRoleCreated = true;
            }
            return isRoleCreated;
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

        public async Task<List<AppUser>> GetUsersAsync()
        {
            List<AppUser> users = new List<AppUser>();
            users = (from u in await _userManager.Users.ToListAsync()
                     select new AppUser()
                     {
                         Email = u.Email,
                         UserName = u.UserName
                     }).ToList();
            return users;
        }

        public async Task<bool> AssignRoleToUserAsync(UserRole user)
        {
            bool isRoleAssigned = false;
            var role = _roleManager.FindByNameAsync(user.RoleName).Result;
            var registeredUser = await _userManager.FindByNameAsync(user.UserName);
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

        public async Task<bool> RegisterUserAsync(RegisterDto register)
        {
            bool IsCreated = false;
            AppUser user = (AppUser)await _userManager.FindByEmailAsync(register.Email);
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
