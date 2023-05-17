using HMS.DAL.Dtos.Reponses;
using Microsoft.AspNetCore.Identity;
using static HMS.DAL.Dtos.Requests.AuthenticationRequest;

namespace HMS.BLL.Interfaces
{
    public interface IAuthenticationServices
    {
     
        Task<IdentityResult> EmailTestAsync();
        Task<AuthResponseDto> UserLogin(LoginDto loginDto);
        Task<IdentityResult> ChangePasswordAsync(string Email, string oldPassword, string newPassword);
        Task<IdentityResult> ConfirmedEmailAsync(string token, string email);
        Task<string> LoginWithOtp(string userName, string code);
        Task<string> ForgetPasswordAsync(string email);
        //Task<string> ResetPasswordAsync(string token, string email);
        Task<ResetPasswordRequest> ResetPasswordAsync(string token, string email);
        Task<string> ResetPasswordAsync(ResetPasswordRequest reset);
        Task<IdentityResult> RegisterUser(RegisterDto register);
        Task<string> VerifyTwoFactorAuth(TwoFactorDto twoFactorDto);
        Task EnableTwoFactorAuth(string userId);
        Task<AuthResponseDto> GoogleLogin(GoogleAuthDto googleAuth);
        Task Logout();

    }
}
