
using HMS.DAL.Entities;

namespace HMS.DAL.Dtos.Requests
{
    public class ReportDto
    {
        public int Id { get; set; }
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
