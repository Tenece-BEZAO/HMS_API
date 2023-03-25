using System.ComponentModel.DataAnnotations;


namespace HMS.DAL.Dtos.Requests
{
    public class RegisterDto
    {
        [Required]
        public string FullName { get; init; }
    
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

       
    }
}
