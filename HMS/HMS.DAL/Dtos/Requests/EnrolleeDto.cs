using HMS.DAL.Entities;

namespace HMS.DAL.Dtos.Requests
{
    public class EnrolleeDTO
    {
        public int Id { get; set; }
        public int? PlanId { get; set; }
        public Plan? Plan { get; set; }
    }
}
