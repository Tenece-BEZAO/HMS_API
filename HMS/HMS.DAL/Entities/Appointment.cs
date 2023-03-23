
namespace HMS.DAL.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Reason { get; set; }
        public int AppUserId { get; set; }
        public AppUser user { get; set; }
    }
}
