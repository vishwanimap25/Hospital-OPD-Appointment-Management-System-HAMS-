using Hospital_OPD___Appointment_Management_System__HAMS_.Data;
using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Entities;
using Hospital_OPD___Appointment_Management_System__HAMS_.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDBcontext _context;

        public DoctorRepository(ApplicationDBcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(Doctor doctor)
        {
           await _context.Doctor.AddAsync(doctor);
        }

        public  void Delete(Doctor doctor)
        {
            _context.Doctor.Remove(doctor);
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            return await _context.Doctor.ToListAsync();
        }

        public async Task<Doctor> GetIdByAsync(int id)
        {
            return await _context.Doctor.FindAsync(id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Doctor doctor)
        {
            _context.Doctor.Update(doctor);
        }
    }
}
