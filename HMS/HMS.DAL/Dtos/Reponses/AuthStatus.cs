using HMS.DAL.Enums;

namespace HMS.DAL.Dtos.Reponses
{
    public class AuthStatus
    {
        public LoginStatus LoginStatus { get; set; }
        public string Token { get; set; }
/*        public string Role { get; set; }
        public string Email { get; set; }
        public bool? RememberMe { get; set; }
        public bool TwoFactorRequired { get; set; }*/
    }
    //public record AuthStatus(LoginStatus LoginStatus, string Token, string Role, string Email, bool? RememberMe, bool TwoFactorRequired);
}
