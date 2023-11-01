using GLDiagonistice.Application.Service.Common;
using GLDiagonistice.Application.Service.ConfigurationService.Dto;

namespace GLDiagonistice.Application.IService.Configuration
{
    public interface IInvestigationService
    {
        public Task<ResponseModel<List<InvestigationDto>>> GetAllInvestigationList();
        public Task<ResponseModel<int>> CreateOrUpdateInvestigation(InvestigationDto investigationDto);
        public Task<ResponseModel<InvestigationDto>> GetInvestigationById(int id);
        public Task<ResponseModel<bool>> DeleteInvestigationById(int id);
    }
}
