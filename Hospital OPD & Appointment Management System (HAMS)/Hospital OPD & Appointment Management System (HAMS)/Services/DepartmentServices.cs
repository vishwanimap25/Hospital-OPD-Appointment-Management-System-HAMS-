using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Dto.Department_Dto;
using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Entities;
using Hospital_OPD___Appointment_Management_System__HAMS_.Repositories.Interfaces;
using Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interfaces;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IDepartmentRepository _repo;

        public DepartmentServices(IDepartmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<Department> CreateDepartment(DepartmentCreateDto dto)
        {
            var newdept = new Department()
            {
                Name = dto.Name,
            };
            await _repo.AddAsync(newdept);
            await _repo.SaveChangesAsync();
            return newdept;
        }  
        

        public async Task<bool> DeleteDepartment(int id)
        {
            var dept = await _repo.GetByIdAsync(id);
            if(dept == null) {return false;}
            _repo.DeleteAsync(dept);
            _repo.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Department>> GetAllDepartement()
        {
            var dept = await _repo.GetAllAsync();
            return dept;
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            var dept = await _repo.GetByIdAsync(id);
            return dept;
        }

        public async Task UpdateDepartment(int id, DepartmentCreateDto dto)
        {
            var existingDept = await _repo.GetByIdAsync(id);
            if (existingDept == null)
                throw new KeyNotFoundException("Department not found");

            // Safely update the Name
            existingDept.Name = dto.Name;

            _repo.UpdateAsync(existingDept); // Just Update, not UpdateAsync
            await _repo.SaveChangesAsync();
        }



    }
}
