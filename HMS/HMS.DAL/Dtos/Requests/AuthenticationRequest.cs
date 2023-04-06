using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Dtos.Requests
{
    public class AuthenticationRequest
    {
        public class LoginDto
        {

            [EmailAddress]
            [Required(ErrorMessage = "User name is required")]
            public string? Email { get; init; }
            [Required(ErrorMessage = "Password name is required")]
            public string? Password { get; init; }
                    
        }


        public class RegisterDto
        {
            [Required]
            public string FirstName { get; init; }
            public string LastName { get; init; }

            [Required(ErrorMessage = "Username is required")]
            public string UserName { get; init; }

            [Required]
            [EmailAddress]
            public string Email { get; init; }
            [Required(ErrorMessage = "Password is required")]
            [DataType(DataType.Password)]
            public string Password { get; init; }

            [Required]
            [Display(Name = "Confirm Password")]
            [Compare("Password", ErrorMessage = "Password and Confirmation Password do not match")]
            public string ConfirmedPassword { get; init; }
            public string? PhoneNumber { get; init; }
            public ICollection<string>? Roles { get; init; }
            [Display(Name = "2 Factor Authentication")]
            public bool TwoFactorEnabled { get; set; } = true;


        }


        public class ChangePasswordDto
        {

            [Required]
            public string Email { get; set; }

            [Required]
            public string CurrentPassword { get; set; }

            [Required]
            public string NewPassword { get; set; }

        }

        public class TwoFactorLoginRequest
        {
            public string UserId { get; set; }
            public string Token { get; set; }
        }
        public class UserRole
        {
            public string Email { get; set; }
            public string RoleName { get; set; }
        }

        public class VerifyAccountRequest
        {
            [Required]
            public string Username { get; set; }
            [Required]
            public string NewPassword { get; set; }
            [Required]
            public string EmailConfirmationAuthenticationToken { get; set; }
            [Required]
            public string ResetPasswordAuthenticationToken { get; set; }

        }


        public class ResetPasswordRequest
        {
            [Required]
            public string Email { get; set; }
            [Required]
            public string Token { get; set; }
            [Required]
            public string NewPassword { get; set; }

            [Compare("Password", ErrorMessage = "your password does not match")]
            public string ConfirmedPassword { get; set; }
        }

        public class UpdateRecoveryMailRequest
        {
            [Required]
            public string UserId { get; set; }

            [Required]
            public string Email { get; set; }
        }

        public class ChangeEmailRequest
        {
            [Required]
            public string NewEmail { get; set; }

            [Required]
            public string Email { get; set; }

            [Required]
            public string Token { get; set; }
        }

        public class ChangeEmailRequestDto
        {
            [Required]
            public string NewEmail { get; set; }

            [Required]
            public string RecoveryEmail { get; set; }
        }
    }
}
