namespace Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
        
    }
}
