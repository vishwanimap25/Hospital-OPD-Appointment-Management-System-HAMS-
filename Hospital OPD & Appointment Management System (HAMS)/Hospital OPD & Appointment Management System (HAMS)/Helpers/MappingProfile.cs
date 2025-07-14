using AutoMapper;
using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Dto.Appointment_dto_folder;
using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Dto.Department_Dto;
using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Dto.Doctor_dto_folder;
using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Dto.Patient_dto_folder;
using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Entities;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //(1) For Doctor Mapping
            CreateMap<Doctor, DoctorReadDto>();
            CreateMap<DoctorCreateDto, Doctor>();

            //(2) For Patient Mapping
            CreateMap<PatientCreateDto, Patient>();

            //(3) For Department Mapping --> no need for this becoz we used manual mapping for department
            CreateMap<DepartmentCreateDto, Department>();  

            //(4) For Appointment Mapping
            CreateMap<AppointmentCreateDto, Appointment>();
            CreateMap<Appointment, AppointmentReadDto>()
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.FullName))
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.FullName));
        }


    }
}
