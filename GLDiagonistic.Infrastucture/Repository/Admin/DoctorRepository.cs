using AutoMapper;
using GLDiagonistic.Infrastucture.Common;
using GLDiagonistice.Application.IRepository;
using GLDiagonistice.Application.Service.Admin.Dto;
using Microsoft.EntityFrameworkCore;

namespace GLDiagonistic.Infrastucture.Repository.Admin
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly GLDDbContext _dbContext;
        private readonly IMapper _mapper;
        public DoctorRepository(GLDDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<List<DoctorDto>> GetAllDoctor()
        {
            try
            {
                var doctorList = await _dbContext.Doctors.AsNoTracking().ToListAsync();
                if (doctorList.Any())
                {
                    return _mapper.Map<List<DoctorDto>>(doctorList);
                }

                return new List<DoctorDto>();

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
