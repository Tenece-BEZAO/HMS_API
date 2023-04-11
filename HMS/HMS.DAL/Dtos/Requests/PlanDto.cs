using HMS.DAL.Enums;


namespace HMS.DAL.Dtos.Requests
{
    public class PlanDto
    {
        public string Name { get; set; } = null!;
        public PlanType PlanType { get; set; }
        public decimal Price { get; set; }
    }
}
