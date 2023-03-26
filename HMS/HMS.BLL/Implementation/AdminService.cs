﻿using HMS.BLL.Interfaces;
using HMS.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BLL.Implementation
{
    public class AdminService : IAdminService
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminService(IConfiguration configuration, SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _configuration = configuration;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
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
                         NormalizedName = r.NormalizedName
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
            // find role associated with the RoleName
            var role = _roleManager.FindByNameAsync(user.RoleName).Result;
            // var registeredUser = new IdentityUser() { UserName = user.User.UserName};
            // find user by name
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
    }
}
