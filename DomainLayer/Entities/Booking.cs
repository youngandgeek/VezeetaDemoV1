using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Entities;
using DomainLayer.Models;

namespace DomainLayer.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [ForeignKey("Patient")]
        public string PatientId { get; set; }

        // Navigation property to represent the relationship with a patient
        public virtual ApplicationUser Patient { get; set; }

        [ForeignKey("Doctor")]
        public string DoctorId { get; set; }

        // Navigation property to represent the relationship with a doctor
        public virtual ApplicationUser Doctor { get; set; }

        [ForeignKey("Appointment")]
        public int AppointmentId { get; set; }

        // Navigation properties to represent the relationships with Appointment
        public virtual Appointment Appointment { get; set; }
    }

}
