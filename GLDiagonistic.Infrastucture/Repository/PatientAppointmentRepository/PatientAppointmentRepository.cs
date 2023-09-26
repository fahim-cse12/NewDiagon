using AutoMapper;
using GLDiagonistic.Domain;
using GLDiagonistic.Infrastucture.Common;
using GLDiagonistice.Application.IRepository;
using GLDiagonistice.Application.Service.Common;
using GLDiagonistice.Application.Service.PatientAppointmentService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLDiagonistic.Infrastucture.Repository.PatientAppointmentRepository
{
    public class PatientAppointmentRepository : IPatientAppointmentRepository
    {
        private readonly GLDDbContext _dbContext;
        private readonly IMapper _mapper;
        public PatientAppointmentRepository(GLDDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }
        public Task<AppointmentDto> GetAppointmentById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PatientDto> GetPatientInfoById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveAndUpdateAppointmentDto(AppointmentDto appointmentDto)
        {
            Appointment aappointment = _mapper.Map<Appointment>(appointmentDto);
            if(appointmentDto.Id > 0)
            {
                _dbContext.Appointments.Update(aappointment);
            }
            else
            {
                await _dbContext.Appointments.AddAsync(aappointment);
            }                   
            await _dbContext.SaveChangesAsync();

            return aappointment.Id;
        }

        public async Task<int> SaveAndUpdatePatientInformation(PatientDto patientDto)
        {
            Patient patient = _mapper.Map<Patient>(patientDto);
            if(patientDto.Id > 0)
            {
                 _dbContext.Patients.Update(patient);
            }
            else
            {
                await _dbContext.Patients.AddAsync(patient);
            }
          
            await _dbContext.SaveChangesAsync();

            return patient.Id;
        }
    }
}
