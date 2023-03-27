
using HMS.DAL.Enums;
using System.ComponentModel.DataAnnotations;


namespace HMS.DAL.Entities
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        public string EnrolleeName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Reason { get; set; }
        public int? EnrolleeId { get; set; }
        public Enrollee? Enrollee { get; set; }
        public Status Status { get; set; } = Status.Pending;
        public int? ProviderId { get; set; }
        public Provider? Provider { get; set; }  
    }
}
