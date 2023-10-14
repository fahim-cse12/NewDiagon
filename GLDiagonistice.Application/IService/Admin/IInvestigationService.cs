using GLDiagonistice.Application.Service.Admin.Dto;
using GLDiagonistice.Application.Service.Common;

namespace GLDiagonistice.Application.IService.Admin
{
    public interface IInvestigationService
    {
        public Task<ResponseModel<List<InvestigationDto>>> GetAllInvestigationList();
        public Task<ResponseModel<int>> CreateOrUpdateInvestigation(InvestigationDto investigationDto);
        public Task<ResponseModel<InvestigationDto>> GetInvestigationById(int id);
        public Task<ResponseModel<bool>> DeleteInvestigationById(int id);
    }
}
