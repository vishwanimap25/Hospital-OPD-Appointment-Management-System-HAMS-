using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Dto.Appointment_dto_folder;
using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Dto.Doctor_dto_folder;
using Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentServices _service;

        public AppointmentController(IAppointmentServices service)
        {
            _service = service;
        }

        //(1)Create new Appointments
        [HttpPost("CreateAppointment")]
        [Authorize(Roles = "Receptionist,Admin")]
        public async Task<ActionResult<DoctorReadDto>> CreateAppointment([FromBody]AppointmentCreateDto dto)
        {
            var createapot = await _service.CreateAppointmentsAync(dto);
            if(createapot == null) {return BadRequest("Enter Appointment details"); }
            return Ok(createapot);
        }

        //(2)Get all Appointments
        [HttpGet("GetAllAppointments")]
        [Authorize(Roles = "Receptionist,Admin")]
        public async Task<ActionResult<IEnumerable<AppointmentReadDto>>> GetAllAppointments()
        {
            var getapots = await _service.GetAllAppointmentsAync();
            if(getapots == null) {return NotFound();}
            return Ok(getapots);
        }

        //(3)Get Appointments by Id
        [HttpGet("GetAppointmentById/{id}")]
        [Authorize(Roles = "Receptionist,Admin")]
        public async Task<ActionResult<AppointmentReadDto>> GetAppointmentById(int id)
        {
            var getapot = await _service.GetAppointmentByIdAsync(id);
            if (getapot == null) { return NotFound("Appointment is not present"); }
            return Ok(getapot);
        }

        //(4)Update Appointments
        [HttpPut("UpdateAppointment/{id}")]
        [Authorize(Roles = "Receptionist,Admin")]
        public async Task<IActionResult> UpdateAppointment(int id, AppointmentCreateDto dto)
        {
            var apot = await _service.UpdateAppointmentAsync(id, dto);
            if (apot == null) { return NotFound(); }
            return Ok("Appointment Updated");
        }

        //(5)Delete Appointments
        [HttpDelete("DeleteAppointment/{id}")]
        [Authorize(Roles = "Receptionist,Admin")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var apot = await _service.DeleteAppointmentAsync(id);
            if (apot == null) { return BadRequest("Enter Valid Id"); }
            return Ok("Appointment Deleted");
        }


    }
}
