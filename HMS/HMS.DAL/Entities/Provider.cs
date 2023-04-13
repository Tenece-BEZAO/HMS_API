
namespace HMS.DAL.Entities
{
    public class Provider : AppUser
    {
        public string Specialty { get; set; }
        public IEnumerable<Appointment>? Appointments { get; set; }
    }
}
