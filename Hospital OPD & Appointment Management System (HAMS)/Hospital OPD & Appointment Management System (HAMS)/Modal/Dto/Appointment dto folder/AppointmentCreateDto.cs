namespace Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Dto.Appointment_dto_folder
{
    public class AppointmentCreateDto
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; } = DateTime.UtcNow;
        public string Reason { get; set; }
        public string Status { get; set; } = "Scheduled";
    }
}
