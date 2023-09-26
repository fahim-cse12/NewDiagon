using GLDiagonistic.Domain;
using GLDiagonistice.Application.IRepository;
using GLDiagonistice.Application.IService.IPatientAppointmentService;
using GLDiagonistice.Application.Service.Common;
using GLDiagonistice.Application.Service.PatientAppointmentService.Dto;
using Microsoft.AspNetCore.Http;

namespace GLDiagonistice.Application.Service.PatientAppointmentService
{
    public class PatientAppointmentService : IAppointmentService
    {
        private readonly IPatientAppointmentRepository _patientAppointmentRepository;
        private readonly IHttpContextAccessor _httpcontext;
        public PatientAppointmentService(IPatientAppointmentRepository patientAppointmentRepository, IHttpContextAccessor httpcontext)
        {
            this._patientAppointmentRepository = patientAppointmentRepository;
            this._httpcontext = httpcontext;    
        }
        private ResponseModel<T> CreateResponse<T>(bool status, T? data, string message, List<string>? erros)
        {
            return new ResponseModel<T>
            {
                Success = status,
                Data = data,
                Message = message,
                Errors = erros
            };
        }
        public async Task<ResponseModel<int>> CreateOrUpdateAppointment(PatientAppointmentDto patientAppointmentDto)
        {
            try
            {
                if(patientAppointmentDto != null)
                {
                    var currentDate = DateTime.Now;
                    var userIdClaim = _httpcontext.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId");
                    var loginUserId = userIdClaim != null ? userIdClaim.Value : null;
                    PatientDto patient = new PatientDto
                    {
                        Id = patientAppointmentDto.PatientId,
                        PatientName = patientAppointmentDto.PatientName,
                        ContactNumber = patientAppointmentDto.ContactNumber,
                        Age = patientAppointmentDto.Age,
                        PatientAddress = patientAppointmentDto.PatientAddress,
                        Gender = patientAppointmentDto.Gender,
                        Email = patientAppointmentDto.Email,
                        IsNew = patientAppointmentDto.IsNew,
                        Status = true,
                        CreatedAt = currentDate,
                        CreatedBy = loginUserId,
                        UpdateddBy = loginUserId,
                        UpdatedAt = currentDate

                    };
                
                    if(patientAppointmentDto.PatientId > 0)
                    {
                        patient.UpdateddBy = loginUserId;
                        patient.UpdatedAt = currentDate;

                    }
                    var patientId = await _patientAppointmentRepository.SaveAndUpdatePatientInformation(patient);
                    if(patientId > 0)
                    {
                        AppointmentDto appointment = new AppointmentDto
                        {
                            Id = patientAppointmentDto.AppointmentId,
                            AppointmentDate = currentDate,
                            AppointmentTime = patientAppointmentDto.AppointmentTime,
                            DoctorId = patientAppointmentDto.DoctorId,
                            PatientId = patientId,
                            InvestigationId = patientAppointmentDto.InvestigationId,
                            Status = true,
                            CreatedAt = currentDate,
                            CreatedBy = loginUserId,
                            UpdateddBy = loginUserId,
                            UpdatedAt = currentDate
                        };
                        if (patientAppointmentDto.AppointmentId > 0)
                        {
                            appointment.UpdateddBy = loginUserId;
                            appointment.UpdatedAt = currentDate;

                        }
                        var appointmentId = await _patientAppointmentRepository.SaveAndUpdateAppointmentDto(appointment); 
                        
                        return CreateResponse(true, appointmentId, "Patient Appointment Created Successfully", null);
                    }                 

                }
                return CreateResponse(true, 0, "Patient and appointment information required", null);
            }
            catch (Exception ex)
            {
                return CreateResponse(false, 0, ex.Message, null);
            }
        }
    }
}
