using Hospital_OPD___Appointment_Management_System__HAMS_.Data;
using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Entities;
using Hospital_OPD___Appointment_Management_System__HAMS_.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDBcontext context;

        public PatientRepository(ApplicationDBcontext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Patient patient)
        {
            await context.Patient.AddAsync(patient);
        }

        public void Delete(Patient patient)
        {
            context.Patient.Remove(patient);
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
           return await context.Patient.ToListAsync();
        }

        public async Task<Patient> GetIdByAsync(int id)
        {
            return await context.Patient.FindAsync(id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void Update(Patient patient)
        {
            context.Patient.Update(patient);
        }

        public async Task<Patient> GetNameEmailAsync(string? name, string? email, string? phone)
        {
            var query = context.Patient.AsQueryable();
            //return await context.Patient
            //    .FirstOrDefaultAsync(u => EF.Functions.Like(u.FullName, $"%{name}%") 
            //    || EF.Functions.Like(u.Email, $"%{email}%"));
            if (!string.IsNullOrEmpty(name))
                query = query.Where(p => EF.Functions.Like(p.FullName, $"%{name}%"));
            if (!string.IsNullOrEmpty(email))
                query = query.Where(p => EF.Functions.Like(p.Email, $"%{email}%"));
            if (!string.IsNullOrEmpty(phone))
                query = query.Where(p => EF.Functions.Like(p.PhoneNumber, $"%{phone}%"));

            return await query.FirstOrDefaultAsync();
        }

       
    }
}
