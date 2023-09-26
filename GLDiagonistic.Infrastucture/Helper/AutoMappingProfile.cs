﻿using AutoMapper;
using GLDiagonistic.Domain;
using GLDiagonistice.Application.Service.Doctor.Dto;
using GLDiagonistice.Application.Service.PatientAppointmentService.Dto;

namespace GLDiagonistic.Infrastucture.Helper
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
            CreateMap<Patient, PatientDto>().ReverseMap();
            CreateMap<Doctor, DoctorDto>().ReverseMap();

        }
    }
}