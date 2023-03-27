
namespace HMS.DAL.Entities
{
    public class Report
    {
        public int Id { get; set; }
        public int? EnrolleId { get; set; }
        public Enrollee Enrollee{ get; set; }

        public int? ProviderId { get; set; }
        public Provider provider{ get; set; }
        public string Name { get; set; }
        public int? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

        public int? PlanId { get; set; }
        public Plan? Plan { get; set; }

        public int? DrugId { get; set; }
        public Drug? Drug { get; set; }

        public string Reason { get; set; }
        public DateTime ReportDate { get; set; }

    }
}
