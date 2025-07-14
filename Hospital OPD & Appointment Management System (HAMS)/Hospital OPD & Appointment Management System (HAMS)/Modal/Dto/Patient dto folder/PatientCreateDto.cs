namespace Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Dto.Patient_dto_folder
{
    public class PatientCreateDto
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Reason { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
    }
}
