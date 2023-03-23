
namespace HMS.DAL.Entities
{
    public class Report
    {
        public int Id { get; set; }

        public int EnrolleeId { get; set; }
        public Enrollee Enrollee { get; set; }

        public int PlanId { get; set; }
        public Plan Plan { get; set; }

        public int DrugId { get; set; }
        public Drug Drug { get; set; }

    }
}
