
namespace HMS.DAL.Entities
{
    public class Report
    {
        public int Id { get; set; }

        public int? EnrolleId { get; set; }
        public Enrollee Enrolle{ get; set; }

        public int? ProviderId { get; set; }
        public Provider provider{ get; set; }

    }
}
