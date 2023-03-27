
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.DAL.Entities
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Reason { get; set; }
        public int? EnrolleId { get; set; }
        public Enrollee enrollee { get; set; }

        public int? ProviderId { get; set; }
        public Provider provider { get; set; }
       
    }
}
