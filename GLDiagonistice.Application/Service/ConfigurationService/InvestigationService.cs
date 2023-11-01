using GLDiagonistice.Application.IRepository;
using GLDiagonistice.Application.IService.Configuration;
using GLDiagonistice.Application.Service.Common;
using GLDiagonistice.Application.Service.ConfigurationService.Dto;
using Microsoft.AspNetCore.Http;

namespace GLDiagonistice.Application.Service.ConfigurationService
{
    public class InvestigationService : IInvestigationService
    {
        private readonly IInvestigationRepository _investigationRepository;
        private readonly IHttpContextAccessor _httpcontext;
        public InvestigationService(IInvestigationRepository investigationRepository, IHttpContextAccessor httpcontext)
        {
            _investigationRepository = investigationRepository;
            _httpcontext = httpcontext;
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

        public Task<ResponseModel<int>> CreateOrUpdateInvestigation(InvestigationDto investigationDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<bool>> DeleteInvestigationById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<InvestigationDto>>> GetAllInvestigationList()
        {
            try
            {
                var investigationList = await _investigationRepository.GetAllInvestigation();
                if (investigationList.Any())
                {
                    return CreateResponse(true, investigationList, "", null);
                }

                return CreateResponse(true, investigationList, "No data found", null);

            }
            catch (Exception ex)
            {
                return CreateResponse<List<InvestigationDto>>(false, null, ex.Message, null);
            }
        }

        public Task<ResponseModel<InvestigationDto>> GetInvestigationById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
