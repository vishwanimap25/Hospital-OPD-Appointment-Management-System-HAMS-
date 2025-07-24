using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Entities;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interfaces
{
    public interface IMedicalRecordService
    {
        Task<IEnumerable<MedicalRecords>> GetAllAsync();
        Task<MedicalRecords> GetByIdAsync(int id);
        Task<IEnumerable<MedicalRecords>> GetPatientByIdAsync(int patientid);
        Task<MedicalRecords> AddAsync(MedicalRecords record);
    }
}
