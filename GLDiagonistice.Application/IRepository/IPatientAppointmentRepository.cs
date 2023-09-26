using GLDiagonistice.Application.Service.Common;
using GLDiagonistice.Application.Service.Doctor.Dto;
using GLDiagonistice.Application.Service.PatientAppointmentService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLDiagonistice.Application.IRepository
{
    public interface IPatientAppointmentRepository
    {
        public Task<int> SaveAndUpdatePatientInformation(PatientDto patientDto );
        public Task<PatientDto> GetPatientInfoById(int id);
        public Task<int> SaveAndUpdateAppointmentDto(AppointmentDto appointmentDto);
        public Task<AppointmentDto> GetAppointmentById(int id);


    }
}
