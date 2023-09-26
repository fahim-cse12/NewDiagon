using GLDiagonistice.Application.Service.Common;
using GLDiagonistice.Application.Service.PatientAppointmentService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLDiagonistice.Application.IService.IPatientAppointmentService
{
    public interface IAppointmentService
    {
        public Task<ResponseModel<int>> CreateOrUpdateAppointment(PatientAppointmentDto patientAppointmentDto);
    }
}
