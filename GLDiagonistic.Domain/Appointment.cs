namespace GLDiagonistic.Domain
{
    public class Appointment : BaseEntity
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int? InvestigationId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }

        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public Investigation Investigations { get; set; }
        public InvestigationResult InvestigationResults { get; set; }
    }
}
