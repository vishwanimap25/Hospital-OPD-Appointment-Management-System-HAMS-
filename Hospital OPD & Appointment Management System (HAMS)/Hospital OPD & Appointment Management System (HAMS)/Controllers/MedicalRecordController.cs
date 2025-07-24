using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Entities;
using Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MedicalRecordController : Controller
    {

        private readonly IMedicalRecordService _service;

        public MedicalRecordController(IMedicalRecordService service)
        {
            _service = service;
        }

        //Add Medical Records
        [HttpPost("AddMedicalRecords")]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> AddMedRec([FromBody]MedicalRecords records)
        {
            var medrecord = await _service.AddAsync(records);
            return Ok("Medical Record Added");
        }

        //Getall Medical Records
        [HttpGet("GetAllMedicalRecord")]
        [Authorize(Roles = "Reception, Admin, Doctor")]
        public async Task<IActionResult> GetAll()
        {
            var medirecord = await _service.GetAllAsync();  
            return Ok(medirecord);
        }

        //Get Medical Records by Id
        [HttpGet("GetMRbyId")]
        [Authorize(Roles = "Reception, Admin, Doctor")]
        public async Task<IActionResult> GetById (int id)
        {
            var medirecord = await _service.GetByIdAsync(id);
            if(medirecord == null) { return BadRequest("Enter Valid Id"); }
            return Ok(medirecord);
        }

        //Get By Patient Id
        [HttpGet("GetByPatientId")]
        [Authorize(Roles = "Reception, Admin, Doctor")]
        public async Task<IActionResult> GetByPatientId(int patientid)
        {
            var medirecord = await _service.GetPatientByIdAsync(patientid);
            if (medirecord == null) { return NotFound(); }
            return Ok(medirecord);
        }


    }
}
