
using HMS.DAL.Enums;

namespace HMS.DAL.Dtos.Requests
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public string EnrolleeName { get; set; }
        public string Reason { get; set; }
        public DateTime AppointmentDate { get; set; }
        
        public Status Status { get; set; } = Status.Pending;
    }
}
