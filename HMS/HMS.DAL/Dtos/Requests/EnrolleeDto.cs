
﻿using HMS.DAL.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

﻿using HMS.DAL.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HMS.DAL.Dtos.Requests
{
    public class EnrolleeDto
    {
        [Required(ErrorMessage = "First name is required"), MaxLength(100)]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Last name is required"), MaxLength(100)]
        public string LastName { get; set; } = null!;

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
       // [ForeignKey("Plan")]
        //public int? PlanId { get; set; }

    }
}
