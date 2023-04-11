using HMS.DAL.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.DAL.Entities
{
    public class Plan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = null!;
        public PlanType PlanType { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }
        public IEnumerable<Enrollee> Enrollees { get; set; } = new List<Enrollee>();
        public Drug Drug { get; set; }
    }
}
