using GLDiagonistice.Application.Service.Common;
using GLDiagonistice.Application.Service.PatientAppointmentService.Dto;

namespace GLDiagonistice.Application.IService.IPatientAppointmentService
{
    public interface IAppointmentService
    {
        public Task<ResponseModel<int>> CreateOrUpdateAppointment(PatientAppointmentDto patientAppointmentDto);
        public Task<ResponseModel<List<PatientAppointmentDto>>> GetAllAppointmentForCurrentDate();
    }
}
