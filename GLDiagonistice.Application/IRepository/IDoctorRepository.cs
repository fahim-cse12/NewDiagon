using GLDiagonistice.Application.Service.ConfigurationService.Dto;

namespace GLDiagonistice.Application.IRepository
{
    public interface IDoctorRepository
    {
        public Task<List<DoctorDto>> GetAllDoctor();
    }
}
