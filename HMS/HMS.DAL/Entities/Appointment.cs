﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.DAL.Entities
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Reason { get; set; }

        /*[ForeignKey("AppUser")]
        public int AppUserId { get; set; }*/
        //public AppUser AppUser { get; set; }
    }
}
