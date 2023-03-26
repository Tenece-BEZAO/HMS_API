using HMS.DAL.Dtos.Reponses;
using HMS.DAL.Dtos.Requests;
using HMS.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Interfaces
{
    public interface IAuthenticationService
    {
         Task<IdentityResult> RegisterUser(RegisterDto userForRegistration);
        Task<AuthStatus> UserLogin(LoginDto loginDto);
        Task<string> GenerateToken();
        Task<IdentityResult> ChangePasswordAsync(string Email, string oldPassword, string newPassword);
        Task Logout();

    }
}
