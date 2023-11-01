using System.ComponentModel.DataAnnotations;

namespace GLDiagonistic.Domain
{
    public class PatientAppointment : BaseEntity
    {
        [Key]
        public long Id { get; set; }
        public string PatientName { get; set; }
        public int PatientAge { get; set; }
        public string PatientGender { get; set; }
        public string PatientAddress { get; set; }
        public string MobileNo { get; set; }
        public int DoctorId { get; set; }
        public decimal DoctorsFee { get; set; }
        public decimal Paid { get; set; }
        public decimal Due { get; set; }

    }
}
