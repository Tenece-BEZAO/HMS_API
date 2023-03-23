
using HMS.DAL.Enums;

namespace HMS.DAL.Entities
{
    public class Plan
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public PlanType PlanType { get; set; }
        public decimal Price { get; set; }  
    }
}
