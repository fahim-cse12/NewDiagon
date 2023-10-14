using GLDiagonistice.Application.Service.Admin.Dto;
using GLDiagonistice.Application.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLDiagonistice.Application.IService.Admin
{
    public interface IDoctorService
    {
        public Task<ResponseModel<List<DoctorDto>>> GetAllDoctorList();
        public Task<ResponseModel<int>> CreateOrUpdateDoctor(DoctorDto doctorDto);
        public Task<ResponseModel<DoctorDto>> GetDoctorById(int id);
        public Task<ResponseModel<bool>> DeleteDoctorById(int id);
    }
}
