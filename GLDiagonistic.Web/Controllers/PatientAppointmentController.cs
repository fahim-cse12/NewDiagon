using GLDiagonistice.Application.IService.IPatientAppointmentService;
using GLDiagonistice.Application.Service.Common;
using GLDiagonistice.Application.Service.PatientAppointmentService.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GLDiagonistic.Web.Controllers
{
    [Authorize]
    public class PatientAppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        public PatientAppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        private ResponseModel<T> CreateResponse<T>(bool status, T data, string message, List<string>? erros)
        {
            return new ResponseModel<T>
            {
                Success = status,
                Data = data,
                Message = message,
                Errors = erros
            };
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ResponseModel<int>> CreateOrUpdatePatientAppointment(PatientAppointmentDto patientAppointmentDto)
        {
            var result = await _appointmentService.CreateOrUpdateAppointment(patientAppointmentDto);
            if(result.Success)
            {
                return CreateResponse(result.Success, result.Data, result.Message,result.Errors);
            }
            return CreateResponse(result.Success, result.Data, result.Message, result.Errors);
        }

        [HttpGet]
        public async Task<ResponseModel<List<PatientAppointmentDto>>> LoadCurrentAllAppointment()
        {
            var result = await _appointmentService.GetAllAppointmentForCurrentDate();
            if (result.Success)
            {
                return CreateResponse(result.Success, result.Data, result.Message, result.Errors);
            }
            return CreateResponse(result.Success, result.Data, result.Message, result.Errors);
        }
    }
}
