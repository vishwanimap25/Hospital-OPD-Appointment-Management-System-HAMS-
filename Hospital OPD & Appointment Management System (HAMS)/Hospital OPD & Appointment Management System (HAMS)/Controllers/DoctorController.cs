using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Dto.Doctor_dto_folder;
using Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : Controller
    {
        private readonly IDoctorServices _service;

        public DoctorController(IDoctorServices service)
        {
            _service = service;
        }


        //(1) Get All Doctors
        [HttpGet("GetAllDoctors")]
        public async Task<ActionResult<IEnumerable<DoctorReadDto>>> GetAllDoctors()
        {
            var doctors = await _service.GetAllDoctors();
            return Ok(doctors);
        }

        //(2) Get Doctors by Id
        [HttpGet("GetDoctorById/{id}")]
        public async Task<ActionResult<DoctorReadDto>> GetDoctorById(int id)
        {
            var doctor = await _service.GetDoctorById(id);
            if(doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }

        //(3) Create new Doctor
        [HttpPost("CreateDoctor")]
        public async Task<ActionResult<DoctorReadDto>> CreateDoctor([FromBody] DoctorCreateDto dto)
        {
            var createdoctor = await _service.CreateDoctor(dto);
            if(createdoctor == null) { return BadRequest("Enter Doctor Details"); }
            return Ok(createdoctor);
        }


        //(4) Update Doctors
        [HttpPut("UpdateDoctor/{id}")]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> UpdateDoctor(int id, DoctorCreateDto dto)
        {
            var result = await _service.UpdateDoctor(id, dto);
            if (!result) { return NoContent(); }
            return Ok("Doctor updated");
        }



        //(5) Delete Doctors
        [HttpDelete("DeleteDoctor/{id}")]
        public async Task<IActionResult> DeleteDoctor (int id)
        {
            var doctor = await _service.DeleteDoctor(id);
            if (!doctor) { return NotFound(); }
            return Ok("Doctor deleted");
        }
    }

    

}
