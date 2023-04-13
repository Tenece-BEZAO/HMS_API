using HMS.DAL.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HMS.DAL.Dtos.Requests
{
    public class EnrolleeDTO
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

        [Display(Name = "2 Factor Authentication")]
        public bool TwoFactorEnabled { get; set; } = true;
        public DateTime RegisteredDate { get; set; }

    }
}
