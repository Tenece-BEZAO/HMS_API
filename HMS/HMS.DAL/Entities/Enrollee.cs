

using HMS.DAL.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.DAL.Entities
{
    public class Enrollee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required"), MaxLength(100)]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Last name is required"), MaxLength(100)]
        public string LastName { get; set; } = null!;

        [MaxLength(100)]
        public string? MiddleName { get; set; }
        public string? Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }

        [ForeignKey(nameof(Plan))]
        public int PlanId { get; set; }
        public Plan Plan { get; set; }

    }
}
