using HMS.DAL.Enums;
using Microsoft.AspNetCore.Identity;

namespace HMS.DAL.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public DateTime RegisteredDate { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }

        /*        public int? EnrolleeId { get; set; }    
                public Enrollee? Enrollee { get; set; }

                public int? ProviderId { get; set; }
                public Provider? Provider { get; set; }*/

    }
}
