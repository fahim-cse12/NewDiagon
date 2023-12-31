﻿using System.ComponentModel.DataAnnotations;

namespace GLDiagonistic.Domain
{
    public class Doctor : BaseEntity
    {
        [Key]
        public int Id { get; set; } 
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
