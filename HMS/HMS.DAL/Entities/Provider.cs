
namespace HMS.DAL.Entities
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public DateTime RegisteredDate { get; set; }
        public IEnumerable<Appointment>? Appointments { get; set; }
    }
}
