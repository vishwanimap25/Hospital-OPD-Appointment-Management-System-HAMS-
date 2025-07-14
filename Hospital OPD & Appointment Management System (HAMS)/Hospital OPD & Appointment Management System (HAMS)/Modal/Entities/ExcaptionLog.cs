namespace Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Entities
{
    public class ExcaptionLog
    {
        public int Id { get; set; }

        public string Action { get; set; }

        public string PerformedBy { get; set; }

        public DateTime PerformedAt { get; set; }

        public string Details { get; set; }
    }
}
