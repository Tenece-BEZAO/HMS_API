using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Entities
{
    public class Enrollee
    {
        public int id { get; set; }
        //public Provider provider { get; set; }  
        public int? PlanId { get; set; }    
        public Plan Plan { get; set; }
        public int?  AppointmentId { get; set; }
        public Appointment appointment { get; set; }    
    }
}
