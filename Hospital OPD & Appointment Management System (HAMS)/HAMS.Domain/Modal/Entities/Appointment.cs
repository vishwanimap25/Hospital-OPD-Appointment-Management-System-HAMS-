using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Entities;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Entities
{
    public class Appointment
    {
        public int Id { get; set; }

        public int PatientId { get; set; } // Foreign key
        public int DoctorId { get; set; }  // Foreign key
        public DateTime AppointmentDate { get; set; } = DateTime.UtcNow;
        public string Reason { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }

    }
}

