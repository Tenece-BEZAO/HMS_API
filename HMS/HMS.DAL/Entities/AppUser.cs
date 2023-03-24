using HMS.DAL.Enums;
using Microsoft.AspNetCore.Identity;

namespace HMS.DAL.Entities
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public string? Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public Plan? plan { get; set; }
        public Appointment? Appointment { get; set; }
    }
}
