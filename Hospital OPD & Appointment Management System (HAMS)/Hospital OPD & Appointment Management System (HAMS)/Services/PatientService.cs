using AutoMapper;
using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Dto.Patient_dto_folder;
using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Entities;
using Hospital_OPD___Appointment_Management_System__HAMS_.Repositories.Interfaces;
using Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interfaces;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Services
{
    public class PatientService : IPatientServices
    {
        private readonly IPatientRepository _repo;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<Patient> CreatePatientAsync(PatientCreateDto dto)
        {
            var patients= _mapper.Map<Patient>(dto);
            await _repo.AddAsync(patients);
            await _repo.SaveChangesAsync();
            return patients;
        }

        public async Task<bool> DeletePatientAsync(int id)
        {
            var patient = await _repo.GetIdByAsync(id);
            if(patient == null) { return false;}
            _repo.Delete(patient);
            return await _repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
           return await _repo.GetAllAsync();

        }
        ////if using PatientReadDto
        //public async Task<IEnumerable<PatientReadDto>> GetAllPatientsAsync()
        //{
        //    var patients = await _repo.GetAllAsync();
        //    return _mapper.Map<IEnumerable<PatientReadDto>>(patients);
        //}

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
           var patient = await _repo.GetIdByAsync(id);
           return patient;

        }

        public async Task<Patient> GetPatientByNnEAsync(string? name, string? email, string? phone)
        {
            var patient = await _repo.GetNameEmailAsync(name, email, phone);
            return patient;
        }

        public async Task<bool> UpdatePatientAsync(int id, PatientCreateDto dto)
        {
            var patient = await _repo.GetIdByAsync(id);
            if(patient == null) { return false;}
            _mapper.Map(dto, patient);
            _repo.Update(patient);
            await _repo.SaveChangesAsync();
            return true;
            //or return await _repo.SaveChangesAsync();
        }
    }
}
