

namespace HMS.DAL.Entities
{
    public class Enrollee
    {
        public int Id { get; set; } 
        public int? PlanId { get; set; }    
        public Plan? Plan { get; set; }
 
    }
}
