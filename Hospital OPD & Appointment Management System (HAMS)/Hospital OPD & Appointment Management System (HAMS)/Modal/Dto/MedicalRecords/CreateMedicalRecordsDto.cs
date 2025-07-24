using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Entities;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Dto.MedicalRecords
{
    public class CreateMedicalRecordsDto
    {
        public string Notes { get; set; }
        public string Prescription { get; set; }
        public DateTime? FollowUpDate { get; set; }

        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
}
