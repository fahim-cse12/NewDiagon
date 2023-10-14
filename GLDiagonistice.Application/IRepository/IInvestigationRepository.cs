using GLDiagonistice.Application.Service.Admin.Dto;

namespace GLDiagonistice.Application.IRepository
{
    public interface IInvestigationRepository
    {
        public Task<List<InvestigationDto>> GetAllInvestigation();
    }
}
