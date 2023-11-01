using GLDiagonistice.Application.IService.Configuration;
using GLDiagonistice.Application.Service.Common;
using GLDiagonistice.Application.Service.ConfigurationService.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GLDiagonistic.Web.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;  
        public DoctorController(IDoctorService doctorService)
        {
            this._doctorService = doctorService;
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


        [HttpGet]
        public async Task<ResponseModel<List<DoctorDto>>> LoadAllDoctorList()
        {
            var result = await _doctorService.GetAllDoctorList();
            if (result.Success)
            {
                return CreateResponse(true, result.Data, result.Message, result.Errors);
            }
            return CreateResponse(false, result.Data, result.Message, result.Errors);
        }
    }
}
