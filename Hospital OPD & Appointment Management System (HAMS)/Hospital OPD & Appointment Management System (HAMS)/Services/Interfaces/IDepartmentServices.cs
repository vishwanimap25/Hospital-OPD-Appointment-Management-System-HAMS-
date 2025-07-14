using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Dto.Department_Dto;
using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Entities;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interfaces
{
    public interface IDepartmentServices 
    {
        Task<IEnumerable<Department>> GetAllDepartement();
        Task<Department> GetDepartmentById (int id);
        Task<Department> CreateDepartment(DepartmentCreateDto dto);
        Task<bool> DeleteDepartment(int id);
        Task UpdateDepartment(int id, DepartmentCreateDto dto);
    }
}
