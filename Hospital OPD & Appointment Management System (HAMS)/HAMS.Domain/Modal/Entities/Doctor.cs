using System.ComponentModel.DataAnnotations;
using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Entities;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string  Specialization { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        
        public string PhoneNumber { get; set; }
        public string Qualification { get; set; }
        [Required]
        
        public string Gender { get; set; }
        public string AvailbilityDays { get; set; }
        
        public TimeSpan? AvailableFrom { get; set; } 
        public TimeSpan? AvailableTo { get; set; }

        //foregin key
        public int DepartmentId { get; set; }
        public Department Department { get; set; } //navigation property.
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        public ICollection<Appointment> Appointment { get; set; }
    }
}


