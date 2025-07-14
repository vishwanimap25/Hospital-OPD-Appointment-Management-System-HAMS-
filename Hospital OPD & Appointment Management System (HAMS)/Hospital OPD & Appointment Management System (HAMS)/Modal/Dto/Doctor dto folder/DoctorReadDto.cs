namespace Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Dto.Doctor_dto_folder
{
    public class DoctorReadDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Specialization { get; set; }
        public string  PhoneNumber { get; set; }
        public string AvailbilityDays { get; set; }
        public TimeSpan AvailableFrom { get; set; } 
        public TimeSpan AvailableTo { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
