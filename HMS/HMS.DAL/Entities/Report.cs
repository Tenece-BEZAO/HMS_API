
namespace HMS.DAL.Entities
{
    public class Report
    {
        public int Id { get; set; }

        public int AppUserId { get; set; }
        public AppUser user { get; set; }

        public int PlanId { get; set; }
        public Plan Plan { get; set; }

        public int DrugId { get; set; }
        public Drug Drug { get; set; }

    }
}
