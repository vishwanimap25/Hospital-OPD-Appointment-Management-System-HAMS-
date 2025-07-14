using AutoMapper;
using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Dto.Doctor_dto_folder;
using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Entities;
using Hospital_OPD___Appointment_Management_System__HAMS_.Repositories;
using Hospital_OPD___Appointment_Management_System__HAMS_.Repositories.Interfaces;
using Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interfaces;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Services
{
    public class DoctorService : IDoctorServices
    {
        private readonly IDoctorRepository _repo;
        private readonly IMapper _mapper;

        public DoctorService(IDoctorRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        

        public async Task<DoctorReadDto> CreateDoctor(DoctorCreateDto dto)
        {
            var doctor = _mapper.Map<Doctor>(dto);
            await _repo.AddAsync(doctor);
            await _repo.SaveChangesAsync();
            return _mapper.Map<DoctorReadDto>(doctor);
        }

        public async Task<bool> DeleteDoctor(int id)
        {
            var doctor = await _repo.GetIdByAsync(id);
            if(doctor == null) {return false;}
            _repo.Delete(doctor);
            return await _repo.SaveChangesAsync();
        }

        public async  Task<IEnumerable<DoctorReadDto>> GetAllDoctors()
        {
            var doctor = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<DoctorReadDto>>(doctor);
        }

        public async Task<DoctorReadDto> GetDoctorById(int id)
        {
            var doctor = await _repo.GetIdByAsync(id);
            return _mapper.Map<DoctorReadDto>(doctor);
        }

        //for update sernarios
        //_mapper.Map(source, destination)
        //    source: the dto with new values
        //    destination: the existing entity to apply changes to
        public async Task<bool> UpdateDoctor(int id, DoctorCreateDto dto)
        {
            var doctor = await _repo.GetIdByAsync(id);
            if(doctor == null) { return false;}
            _mapper.Map(dto, doctor);
            //if (!string.IsNullOrEmpty(dto.FullName)) { doctor.FullName =  dto.FullName; }

            _repo.Update(doctor);
            return await _repo.SaveChangesAsync();
        }
    }
}
