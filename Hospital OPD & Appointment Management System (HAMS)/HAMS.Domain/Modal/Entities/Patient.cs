using System.ComponentModel.DataAnnotations;
using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Entities;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        [StringLength(10)]
        [Required]
        public string Gender { get; set; }

        public string Reason { get; set; }
        [Required]
        public DateOnly DateOfBirth { get; set; }
        [MaxLength(10)]
        [Required]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public string Email { get; set; } = string.Empty;

        //internal use only
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        public ICollection<Appointment> Appointment { get; set; }  
    }
}