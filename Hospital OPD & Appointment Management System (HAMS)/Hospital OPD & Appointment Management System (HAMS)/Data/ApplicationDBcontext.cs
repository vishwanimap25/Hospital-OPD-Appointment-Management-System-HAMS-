using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Data
{
    public class ApplicationDBcontext : DbContext
    {
        public ApplicationDBcontext(DbContextOptions options) : base(options)
        {

        }

        //protected ApplicationDBcontext()
        //{
        //}



        //datasets
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<MedicalRecords> MedicalRecords { get; set; }

    }

}
