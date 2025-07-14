using System.ComponentModel.DataAnnotations;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } // "Admin", "Doctor", "Reception"

    }
}
