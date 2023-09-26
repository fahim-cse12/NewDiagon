using GLDiagonistice.Application.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLDiagonistice.Application.Service.Doctor.Dto
{
    public class DoctorDto : BaseEntityDto
    {
        public string DoctorName { get; set; }
        public string Gender { get; set; }
        public string? ContactNumber { get; set; }
        public decimal DoctorsFee { get; set; }
        public string? Email { get; set; }
        public string? SpecialistOn { get; set; }
        public string? ScheduleDays { get; set; }
        public TimeSpan? ScheduleTime { get; set; }
    }
}
