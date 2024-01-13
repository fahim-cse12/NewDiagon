using GLDiagonistice.Application.Service.Common;

namespace GLDiagonistice.Application.Service.ConfigurationService.Dto
{
    public class DoctorDto : BaseEntityDto
    {
        public int Id { get; set; } 
        public string DoctorName { get; set; }
        public string Gender { get; set; }
        public string? ContactNumber { get; set; }
        public Fees DoctorsFee { get; set; }
        public string? Email { get; set; }
        public string? SpecialistOn { get; set; }
        public string? ScheduleDays { get; set; }
        public TimeSpan? ScheduleTime { get; set; }
    }

    public class Fees
    {
        public string ForNew { get; set; }
        public string ForOld { get; set; }
    }
}
