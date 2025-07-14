using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Dto.Department_Dto;
using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Entities;
using Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Controllers
{
    [ApiController]
    [Route("api[controller]")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentServices _service;

        public DepartmentController(IDepartmentServices service)
        {
            _service = service;
        }

        //(1)Create New Department
        [HttpPost("CreateDepartment")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateDepartment([FromBody]DepartmentCreateDto dto)
        {
            
            if (string.IsNullOrEmpty(dto.Name))
            {
                return BadRequest("Department name is required");
            }
            var createdept = await _service.CreateDepartment(dto);
            return Ok($"Department created with ID {createdept.Id} and Name {createdept.Name}");
        }

        //(2)Get All Department 
        [HttpGet("GetAllDepartment")]
        [Authorize(Roles = "Reception,Admin")]
        public async Task<ActionResult<IEnumerable<Department>>> GetAllDepartment()
        {
            var dept = await _service.GetAllDepartement();
            if(dept == null) { NotFound(); }
            return Ok(dept);
        }

        //(3)Get Dept by Id
        [HttpGet("GetDepartmentById/{id}")]
        [Authorize(Roles = "Reception, Admin")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var dept = await _service.GetDepartmentById(id);
            if (dept == null) { NotFound(); }
            return Ok(dept);
        }

        //(4)Update Department
        [HttpPut("UpdateDepartment/{id}")]
        [Authorize(Roles = "Reception, Admin")]
        public async Task<ActionResult<Department>> UpdateDepartment(int id, [FromBody] DepartmentCreateDto dto)
        {
            var dept = await _service.GetDepartmentById(id);
            if (dept == null) { return NotFound("Department not found"); }

            await _service.UpdateDepartment(id, dto);
            return Ok("Department updated successfully");
        }



        //(5)Delete Department
        [HttpDelete("DeleteDepartmentById/{id}")]
        [Authorize(Roles = "Reception, Admin")]
        public async Task<IActionResult> DeleteDepartmentById(int id)
        {
            try
            {
                var result = await _service.DeleteDepartment(id);
                if (!result)
                    return NotFound("Department not found or already deleted.");

                return Ok("Department deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting department: {ex.Message}");
            }

            
        }
        //[HttpDelete("DeleteDepartmentbyId/{id}")]
        //public async Task<IActionResult> DeleteDepartmentbyId(int id)
        //{
        //    var dept = await _service.DeleteDepartment(id);
        //    return Ok("Deparment Deleted");

        //}
    }
}
