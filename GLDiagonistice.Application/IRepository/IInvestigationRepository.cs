using GLDiagonistice.Application.Service.ConfigurationService.Dto;

namespace GLDiagonistice.Application.IRepository
{
    public interface IInvestigationRepository
    {
        public Task<List<InvestigationDto>> GetAllInvestigation();
    }
}
