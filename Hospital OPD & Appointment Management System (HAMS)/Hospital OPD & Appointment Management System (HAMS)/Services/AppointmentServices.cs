using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Dto.Appointment_dto_folder;
using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Entities;
using Hospital_OPD___Appointment_Management_System__HAMS_.Repositories.Interfaces;
using Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interfaces;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Services
{
    public class AppointmentServices : IAppointmentServices
    {
        private readonly IAppointmentRepository _repo;
        private readonly IPatientRepository _patientrepo;
        private readonly IDoctorRepository _doctorepo;
        private readonly IEmailService _emailservice;

        public AppointmentServices(IAppointmentRepository repo, IPatientRepository patientrepo, IDoctorRepository doctorepo, IEmailService emailservice)
        {
            _repo = repo;
            _patientrepo = patientrepo;
            _doctorepo = doctorepo;
            _emailservice = emailservice;
        }

        public async Task<AppointmentReadDto> CreateAppointmentsAync(AppointmentCreateDto dto)
        {
            try
            {
                var patient = await _patientrepo.GetIdByAsync(dto.PatientId);
                var doctor = await _doctorepo.GetIdByAsync(dto.DoctorId);

                if (patient == null || doctor == null)
                    throw new InvalidOperationException("Patient or Doctor not found");

                var appointment = new Appointment
                {
                    PatientId = dto.PatientId,
                    DoctorId = dto.DoctorId,
                    AppointmentDate = dto.AppointmentDate,
                    Reason = dto.Reason,
                    Status = dto.Status,
                    CreatedAt = DateTime.UtcNow
                };

                await _repo.AddAsync(appointment);
                await _repo.SaveChangesAsync();

                string subject = "Appointment Confirmation";
                string body = $@"
                 <p>Dear <strong>{patient.FullName}</strong>,</p>
                 <p>Your appointment with <strong>Dr. {doctor.FullName}</strong> is confirmed for <strong>{dto.AppointmentDate:dddd, MMMM dd, yyyy hh:mm tt}</strong>.</p>
                 <p><em>Reason:</em> {dto.Reason}</p>
                 <br/>
                 <p>Thank you,<br/>Hospital OPD & Appointment Management System</p>";

                await _emailservice.SendEmailAsync(patient.Email, subject, body);

                return new AppointmentReadDto
                {
                    Id = appointment.Id,
                    PatientId = appointment.PatientId,
                    PatientName = patient.FullName,
                    DoctorId = appointment.DoctorId,
                    DoctorName = doctor.FullName,
                    AppointmentDate = appointment.AppointmentDate,
                    Reason = appointment.Reason,
                    Status = appointment.Status,
                    CreatedAt = appointment.CreatedAt
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] AppointmentService: {ex.Message}");
                throw;
            }
        }



        public async Task<bool> DeleteAppointmentAsync(int id)
        {
            var apot = await _repo.GetIdByAsync(id);
            if(apot == null)
            {
                return false;
            }
            _repo.Delete(apot);
            await _repo.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<AppointmentReadDto>> GetAllAppointmentsAync()
        {
            var apot = await _repo.GetAllAsync();
            
            var result = new List<AppointmentReadDto>();

            foreach(var appointment in apot)
            {
                var patient = await _patientrepo.GetIdByAsync(appointment.PatientId);
                var doctor = await _doctorepo.GetIdByAsync(appointment.DoctorId);


                result.Add(new AppointmentReadDto
                {
                    Id = appointment.Id,
                    PatientId = appointment.PatientId,
                    PatientName = patient?.FullName,  
                    DoctorId = appointment.DoctorId,
                    DoctorName = doctor?.FullName,
                    AppointmentDate = appointment.AppointmentDate,
                    Reason = appointment.Reason,
                    Status = appointment.Status,
                    CreatedAt = appointment.CreatedAt
                });
            }

            return result;
        }

        public async Task<AppointmentReadDto> GetAppointmentByIdAsync(int id)
        {
            var apot = await _repo.GetIdByAsync(id);
            if (apot == null) { return null; }
            var patient = await _patientrepo.GetIdByAsync(apot.PatientId);
            var doctor = await _doctorepo.GetIdByAsync(apot.DoctorId);


            return new AppointmentReadDto
            {
                Id = apot.Id,
                PatientId = apot.PatientId,
                PatientName = patient?.FullName, // null-safe
                DoctorId = apot.DoctorId,
                DoctorName = doctor?.FullName,   // null-safe
                AppointmentDate = apot.AppointmentDate,
                Reason = apot.Reason,
                Status = apot.Status,
                CreatedAt = apot.CreatedAt,
            };
        }

        public async Task<AppointmentReadDto> UpdateAppointmentAsync(int id, AppointmentCreateDto dto)
        {
            var appointment = await _repo.GetIdByAsync(id);
            if(appointment == null) { return null; }

            var patient = await _patientrepo.GetIdByAsync(dto.PatientId);
            var doctor = await _doctorepo.GetIdByAsync(dto.DoctorId);
            if(patient == null || doctor == null)
            {
                return null;
            }

            // Update existing fields
            appointment.PatientId = dto.PatientId;
            appointment.DoctorId = dto.DoctorId;
            appointment.AppointmentDate = dto.AppointmentDate;
            appointment.Reason = dto.Reason;
            appointment.Status = dto.Status;
            appointment.CreatedAt = DateTime.UtcNow;

            _repo.Update(appointment);
            await _repo.SaveChangesAsync();


            return new AppointmentReadDto
            {
                Id = appointment.Id,
                PatientId = appointment.Id,
                PatientName = patient.FullName,
                DoctorId = appointment.DoctorId,
                DoctorName = doctor.FullName,
                AppointmentDate = appointment.AppointmentDate,
                Reason = appointment.Reason,
                Status = appointment.Status,
                CreatedAt = DateTime.UtcNow,
            };
        }
    }
}
