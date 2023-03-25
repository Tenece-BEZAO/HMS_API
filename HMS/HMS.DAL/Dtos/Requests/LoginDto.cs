using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Dtos.Requests
{
    public class LoginDto
    {
        
        [EmailAddress]
        [Required(ErrorMessage = "User name is required")]
        public string? Email { get; init; }
        [Required(ErrorMessage = "Password name is required")]
        public string? Password { get; init; }
    }
 
}
