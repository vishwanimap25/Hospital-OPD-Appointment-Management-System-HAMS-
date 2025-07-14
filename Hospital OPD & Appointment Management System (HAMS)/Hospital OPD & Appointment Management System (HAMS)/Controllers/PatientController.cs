using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Dto.Patient_dto_folder;
using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Entities;
using Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : Controller
    {
        private readonly IPatientServices _service;

        public PatientController(IPatientServices service)
        {
            _service = service;
        }


        //(1)Create Patient
        [HttpPost("CreatePatient")]
        public async Task<IActionResult> CreatePatient([FromBody] PatientCreateDto dto)
        {
            var createpatient = await _service.CreatePatientAsync(dto);
            if (createpatient == null) { return BadRequest("Enter Patient Details"); }
            return Ok(createpatient);
        }

        //(2)Get all Patient
        [HttpGet("GetAllPatient")]
        public async Task<ActionResult<IEnumerable<Patient>>> GetAllPatient()
        {
            var patient = await _service.GetAllPatientsAsync();
            return Ok(patient);
        }

        //(3)Get Patient By id
        [HttpGet("GetPatientById/{id}")]
        public async Task<ActionResult<Patient>> GetPatientById(int id)
        {
            var patient = await _service.GetPatientByIdAsync(id);
            if(patient == null) { return BadRequest("Enter proper Id"); }
            return Ok(patient);
        }

        //(4)Get Patient By Name || email
        [HttpGet("GetPatientByNameEmail")]
        public async Task<ActionResult<Patient>> GetPatientByNameEmail([FromQuery]string? name, [FromQuery]string? email, [FromQuery]string? phone)
        {
            //do not use [FromBody] with multiple paramerters
            //instead use [FromQuery]

            var patient = await _service.GetPatientByNnEAsync(name, email, phone);
            if(patient == null) { return BadRequest("Enter Valid Name/ Email/ Phone Number"); }
            return Ok(patient);
        }

        //(5)Update Patient Details
        [HttpPut("UpdatePatient/{id}")]
        public async Task<IActionResult> UpdatePatient( int id, [FromBody] PatientCreateDto dto)
        {
            var patient = await _service.UpdatePatientAsync(id, dto);
            if (!patient) { return NoContent(); }
            return Ok("Updated Patient Details");

        }

        //(6)Delete Patient
        [HttpDelete("DeletePatient/{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await _service.DeletePatientAsync(id);
            if (!patient) { return NoContent(); }
            return Ok("Deleted patient");
        }
    }
}
