using System.Threading.Tasks;
using Hospital_OPD___Appointment_Management_System__HAMS_.Data;
using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Entities;
using Hospital_OPD___Appointment_Management_System__HAMS_.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDBcontext context;

        public AppointmentRepository(ApplicationDBcontext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Appointment appointment)
        {
            await context.AddAsync(appointment); 
        }

        public void Delete(Appointment appointment)
        {
            context.Appointments.Remove(appointment);
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            return await context.Appointments.ToListAsync();
        }

        public async Task<Appointment?> GetIdByAsync(int id)
        {
            return await context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
           return await context.SaveChangesAsync() > 0;
        }

        public void Update(Appointment appointment)
        {
            context.Appointments.Update(appointment);
        }
    }
}
