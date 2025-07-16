using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Dto.Appointment_dto_folder;
using Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentServices _service;

        public AppointmentController(IAppointmentServices service)
        {
            _service = service;
        }

        // (1) Create new Appointment
        [HttpPost("CreateAppointment")]
        [Authorize(Roles = "Reception,Admin")]
        public async Task<ActionResult<AppointmentReadDto>> CreateAppointment([FromBody] AppointmentCreateDto dto)
        {
            try
            {
                var createdAppt = await _service.CreateAppointmentsAync(dto);

                return Ok(createdAppt);
                // Or just: return Ok(createdAppt);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message); // e.g. "Doctor or Patient not found"
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the appointment.");
            }
        }

        // (2) Get all Appointments
        [HttpGet("GetAllAppointments")]
        [Authorize(Roles = "Reception,Admin")]
        public async Task<ActionResult<IEnumerable<AppointmentReadDto>>> GetAllAppointments()
        {
            var appointments = await _service.GetAllAppointmentsAync();
            if (appointments == null || !appointments.Any())
            {
                return NotFound("No appointments found.");
            }

            return Ok(appointments);
        }

        // (3) Get Appointment by Id
        [HttpGet("GetAppointmentById/{id}")]
        [Authorize(Roles = "Reception,Admin")]
        public async Task<ActionResult<AppointmentReadDto>> GetAppointmentById(int id)
        {
            var appointment = await _service.GetAppointmentByIdAsync(id);
            if (appointment == null)
            {
                return NotFound("Appointment not found.");
            }

            return Ok(appointment);
        }

        // (4) Update Appointment
        [HttpPut("UpdateAppointment/{id}")]
        [Authorize(Roles = "Reception,Admin")]
        public async Task<IActionResult> UpdateAppointment(int id, [FromBody] AppointmentCreateDto dto)
        {
            var updated = await _service.UpdateAppointmentAsync(id, dto);
            if (updated == null)
            {
                return NotFound("Appointment not found or update failed.");
            }

            return Ok("Appointment updated successfully.");
        }

        // (5) Delete Appointment
        [HttpDelete("DeleteAppointment/{id}")]
        [Authorize(Roles = "Reception,Admin")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var deleted = await _service.DeleteAppointmentAsync(id);
            if (deleted == null)
            {
                return BadRequest("Invalid appointment ID or deletion failed.");
            }

            return Ok("Appointment deleted successfully.");
        }
    }
}
