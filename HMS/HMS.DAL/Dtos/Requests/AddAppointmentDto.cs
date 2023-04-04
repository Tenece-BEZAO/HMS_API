
namespace HMS.DAL.Dtos.Requests
{
    public class AddAppointmentDto
    {
        public string EnrolleeName { get; set; }
        public string Reason { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
