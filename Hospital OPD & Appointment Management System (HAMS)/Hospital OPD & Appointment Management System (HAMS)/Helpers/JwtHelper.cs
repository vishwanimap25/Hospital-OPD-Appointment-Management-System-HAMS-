namespace Hospital_OPD___Appointment_Management_System__HAMS_.Helpers
{
    public class JwtHelper
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpiresInMinutes { get; set; }
    }
}
