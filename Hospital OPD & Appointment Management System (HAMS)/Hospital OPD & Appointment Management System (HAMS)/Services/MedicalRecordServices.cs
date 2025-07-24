using Hospital_OPD___Appointment_Management_System__HAMS_.Data;
using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Entities;
using Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Services
{
    public class MedicalRecordServices : IMedicalRecordService
    {
        private readonly ApplicationDBcontext _context;

        public MedicalRecordServices(ApplicationDBcontext context)
        {
            _context = context;
        }

        public async Task<MedicalRecords> AddAsync(MedicalRecords record)
        {
            await _context.MedicalRecords.AddAsync(record);
            await _context.SaveChangesAsync();  
            return record;
        }

        public async Task<IEnumerable<MedicalRecords>> GetAllAsync()
        {
            return await _context.MedicalRecords
                                 .Include(p => p.PatientId)
                                 .Include(d => d.DoctorId)
                                 .ToListAsync();
        }

        public async Task<MedicalRecords> GetByIdAsync(int id)
        {
            return await _context.MedicalRecords
                .Include(p => p.PatientId)
                .Include(d => d.DoctorId)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<MedicalRecords>> GetPatientByIdAsync(int patientid)
        {
            return await _context.MedicalRecords
                .Where(u => u.PatientId == patientid)
                .Include(d => d.DoctorId).ToListAsync();
        }
    }
}
