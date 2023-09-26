using GLDiagonistice.Application.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLDiagonistice.Application.Service.PatientAppointmentService.Dto
{
    public class PatientDto : BaseEntityDto
    {
        public string PatientName { get; set; }
        public string PatientAddress { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }
        public string? Email { get; set; }
        public bool IsNew { get; set; }
    }
}
