using GLDiagonistice.Application.IService.Admin;
using GLDiagonistice.Application.Service.Admin.Dto;
using GLDiagonistice.Application.Service.Admin;
using GLDiagonistice.Application.Service.Common;
using Microsoft.AspNetCore.Mvc;

namespace GLDiagonistic.Web.Controllers
{
    public class InvestigationController : Controller
    {
        private readonly IInvestigationService _investigationService;
        public InvestigationController(IInvestigationService investigationService)
        {
            this._investigationService = investigationService;
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
        public async Task<ResponseModel<List<InvestigationDto>>> LoadAllInvestigationList()
        {
            var result = await _investigationService.GetAllInvestigationList();
            if (result.Success)
            {
                return CreateResponse(true, result.Data, result.Message, result.Errors);
            }
            return CreateResponse(false, result.Data, result.Message, result.Errors);
        }
    }
}
