using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Dto.Doctor_dto_folder;
using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Dto.Patient_dto_folder;
using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Entities;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interfaces
{
    public interface IPatientServices
    {
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
        Task<Patient> GetPatientByIdAsync(int id);
        Task<Patient> CreatePatientAsync(PatientCreateDto dto);
        Task<bool> UpdatePatientAsync(int id, PatientCreateDto dto);
        Task<bool> DeletePatientAsync(int id);
        Task<Patient> GetPatientByNnEAsync(string name, string email, string phone);
    }
}
