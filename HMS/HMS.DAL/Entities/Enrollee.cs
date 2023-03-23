
using HMS.DAL.Enums;

namespace HMS.DAL.Entities
{
    public class Enrollee
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        public int PlanId { get; set; }
        public Plan Plan { get; set; }
    }
}
