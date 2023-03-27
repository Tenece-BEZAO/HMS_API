using HMS.DAL.Dtos.Reponses;
using Microsoft.AspNetCore.Identity;
using static HMS.DAL.Dtos.Requests.AuthenticationRequest;

namespace HMS.BLL.Interfaces
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(RegisterDto userForRegistration);
        Task<AuthStatus> UserLogin(LoginDto loginDto);
        Task<IdentityResult> ChangePasswordAsync(string Email, string oldPassword, string newPassword);
        Task Logout();

    }
}
