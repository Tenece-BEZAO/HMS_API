
namespace HMS.DAL.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

  
    public class Report
    {
        [Key]
        public int Id { get; set; }

        public string? EnrolleeId { get; set; }

        [ForeignKey("EnrolleeId")]
        public virtual AppUser Enrollee { get; set; }

        [Required]
        public string Name { get; set; }

        public string? ProviderId { get; set; }

        [ForeignKey("ProviderId")]
        public virtual AppUser Provider { get; set; }


        public int? PlanId { get; set; }

        [ForeignKey("PlanId")]
        public virtual Plan Plan { get; set; }

        public int? DrugId { get; set; }

        [ForeignKey("DrugId")]
        public virtual Drug Drug { get; set; }

        [Required]
        public string Reason { get; set; }

        [Required]
        public DateTime ReportDate { get; set; }
    }

    /*public class Report
    {
        public int Id { get; set; }
        public int? EnrolleId { get; set; }
        public Enrollee? Enrollee{ get; set; }

        public int? ProviderId { get; set; }
        public Provider? provider{ get; set; }
        public string Name { get; set; }

        public int? PlanId { get; set; }
        public Plan? Plan { get; set; }

        public int? DrugId { get; set; }
        public Drug? Drug { get; set; }

        public string Reason { get; set; }
        public DateTime ReportDate { get; set; }

    }*/
}
