using AutoMapper;
using GLDiagonistic.Infrastucture.Common;
using GLDiagonistice.Application.IRepository;
using GLDiagonistice.Application.Service.Admin.Dto;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GLDiagonistic.Infrastucture.Repository.Admin
{
    public class InvestigationRepository : IInvestigationRepository
    {
        private readonly GLDDbContext _dbContext;
        private readonly IMapper _mapper;
        public InvestigationRepository(GLDDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<InvestigationDto>> GetAllInvestigation()
        {
            try
            {
                var investigationList = await _dbContext.Investigations.AsNoTracking().ToListAsync();
                if (investigationList.Any())
                {
                    return _mapper.Map<List<InvestigationDto>>(investigationList);
                }

                return new List<InvestigationDto>();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
