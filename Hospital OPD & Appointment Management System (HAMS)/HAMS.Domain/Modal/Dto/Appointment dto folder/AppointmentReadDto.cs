namespace Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Dto.Appointment_dto_folder
{
    public class AppointmentReadDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
