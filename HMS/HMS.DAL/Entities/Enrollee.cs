

namespace HMS.DAL.Entities
{
    public class Enrollee : AppUser
    {
        public int? PlanId { get; set; }
        public Plan? Plan { get; set; }

    }
}
