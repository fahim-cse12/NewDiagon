using AutoMapper;
using GLDiagonistic.Domain;
using GLDiagonistice.Application.Service.ConfigurationService.Dto;
using GLDiagonistice.Application.Service.PatientAppointmentService.Dto;

namespace GLDiagonistic.Infrastucture.Helper
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<PatientAppointment, PatientAppointmentDto>().ReverseMap();
            CreateMap<Doctor, DoctorDto>().ReverseMap();
            CreateMap<Investigation, InvestigationDto>().ReverseMap();

        }
    }
}
