using System.ComponentModel.DataAnnotations;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Dto.Doctor_dto_folder
{
    //public class DoctorCreateDto
    //{
    //    public string FullName { get; set; }
    //    public string Specialization { get; set; }
    //    public string Email { get; set; }

    //    public string PhoneNumber { get; set; }
    //    public string Qualification { get; set; }

    //    public string Gender { get; set; }
    //    public string AvailbilityDays { get; set; }

    //    public TimeSpan AvailableFrom { get; set; }  
    //    public TimeSpan AvailableTo { get; set; }
    //    public bool IsActive { get; set; }

    //    public int DepartmentId { get; set; }

    //}
    public class DoctorCreateDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Qualification { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string AvailbilityDays { get; set; } = string.Empty;
        public string AvailableFrom { get; set; } = string.Empty;
        public string AvailableTo { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public int DepartmentId { get; set; }

    }

}
