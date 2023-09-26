using AutoMapper;
using GLDiagonistic.Infrastucture.Common;
using GLDiagonistice.Application.IRepository;
using GLDiagonistice.Application.Service.Doctor.Dto;
using Microsoft.EntityFrameworkCore;

namespace GLDiagonistic.Infrastucture.Repository.DoctorRepository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly GLDDbContext _dbContext;
        private readonly IMapper _mapper;
        public DoctorRepository(GLDDbContext dbContext, IMapper mapper) 
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
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
