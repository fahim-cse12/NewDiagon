using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLDiagonistice.Application.Service.PatientAppointmentService.Dto
{
    public class PatientAppointmentDto
    {
        public int AppointmentId { get; set; }
        public string PatientName { get; set; }
        public string PatientAddress { get; set; }
        public bool IsNew { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }
        public string? Email { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public decimal DoctorFee { get; set; }
        public int? InvestigationId { get; set; }
        public string InvestigationName { get; set; }
        public decimal InvestigationFee { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
    }
}
