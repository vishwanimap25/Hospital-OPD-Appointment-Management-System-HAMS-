using Hospital_OPD___Appointment_Management_System__HAMS_.Data;
using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Entities;
using Hospital_OPD___Appointment_Management_System__HAMS_.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDBcontext _context;

        public DepartmentRepository(ApplicationDBcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(Department department)
        {
            await _context.Department.AddAsync(department);
        }

        public void DeleteAsync(Department department)
        {
            _context.Department.Remove(department);
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await _context.Department.ToListAsync();
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            return await _context.Department.FindAsync(id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateAsync(Department department)
        {
            _context.Department.Update(department);
        }
    }
}
