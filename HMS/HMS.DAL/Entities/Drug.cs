
namespace HMS.DAL.Entities
{
    public class Drug
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int PlanId { get; set; }
        public Plan Plan { get; set; }
    }
}
