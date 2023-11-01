using GLDiagonistice.Application.Service.Common;
using GLDiagonistice.Application.Service.ConfigurationService.Dto;

namespace GLDiagonistice.Application.IService.Configuration
{
    public interface IDoctorService
    {
        public Task<ResponseModel<List<DoctorDto>>> GetAllDoctorList();
        public Task<ResponseModel<int>> CreateOrUpdateDoctor(DoctorDto doctorDto);
        public Task<ResponseModel<DoctorDto>> GetDoctorById(int id);
        public Task<ResponseModel<bool>> DeleteDoctorById(int id);
    }
}
