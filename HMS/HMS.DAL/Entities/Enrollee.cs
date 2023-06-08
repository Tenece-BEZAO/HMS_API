using HMS.DAL.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.DAL.Entities
{
    //public class Enrollee : AppUser
    public class Enrollee : IdentityUser
    {
        public int? PlanId { get; set; }
        public Plan? Plan { get; set; }
    }
}
