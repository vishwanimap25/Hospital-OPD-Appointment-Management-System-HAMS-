using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Entities;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        Task AddAsync(Department department);
        Task<IEnumerable<Department>> GetAllAsync();
        Task<Department> GetByIdAsync(int id);
        void UpdateAsync (Department department);
        void DeleteAsync (Department department);
        Task<bool> SaveChangesAsync();
    }
}
