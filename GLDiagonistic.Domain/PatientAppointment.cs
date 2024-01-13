using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLDiagonistic.Domain
{
    [Table("PatientAppointment")]
    public class PatientAppointment : BaseEntity
    {
        [Key]
        public long Id { get; set; } = 0;
        public string PatientName { get; set; }
        public int PatientAge { get; set; }
        public string PatientGender { get; set; }
        public string PatientAddress { get; set; }
        public string MobileNo { get; set; }
        public string PatientType { get; set; }
        public int DoctorId { get; set; }
        public decimal DoctorsFee { get; set; }
        public decimal Paid { get; set; }
        public decimal Due { get; set; }

    }
}
