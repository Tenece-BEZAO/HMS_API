using HMS.DAL.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.DAL.Entities
{
    public class Enrollee : AppUser
    {
        public int? PlanId { get; set; }
        public Plan? Plan { get; set; }
    }
}
