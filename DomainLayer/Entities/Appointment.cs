using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        // Foreign key property to associate with a doctor
        /**  [ForeignKey("Doctor")]
          public int DoctorId { get; set; }
          // Navigation property to represent the relationship with a doctor
     //     public Doctor Doctors { get; set; }
      
         **/
        // Foreign key property to associate with a doctor
        [ForeignKey("Doctor")]
        public string DoctorId { get; set; }
        // Navigation property to represent the relationship with a doctor
        public virtual ApplicationUser Doctor { get; set; }

        // Navigation property to represent the relationship with bookings
        public virtual Booking Booking { get; set; }
    }
}

