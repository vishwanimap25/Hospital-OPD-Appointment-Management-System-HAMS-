using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Dto.Doctor_dto_folder;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interfaces
{
    public interface IDoctorServices
    {
        Task<IEnumerable<DoctorReadDto>> GetAllDoctors();
        Task<DoctorReadDto> GetDoctorById(int id);
        Task<DoctorReadDto> CreateDoctor(DoctorCreateDto dto);
        Task<bool> UpdateDoctor(int id, DoctorCreateDto dto);
        Task<bool> DeleteDoctor(int id);
    }
}
