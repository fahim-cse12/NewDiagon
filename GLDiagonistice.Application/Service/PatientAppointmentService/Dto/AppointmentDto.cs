using GLDiagonistice.Application.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLDiagonistice.Application.Service.PatientAppointmentService.Dto
{
    public class AppointmentDto : BaseEntityDto
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int? InvestigationId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }

    }
}
