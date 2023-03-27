using HMS.DAL.Enums;
using Microsoft.AspNetCore.Identity;

namespace HMS.DAL.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string? Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        /*public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }*/

        public int? PlanId { get; set; }    
        public Plan? Plan { get; set; }

        public int? AppointmentId { get; set; }
        public Appointment? Appointment { get; set; }
    }
}
