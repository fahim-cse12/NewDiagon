using GLDiagonistice.Application.Service.Common;
using GLDiagonistice.Application.Service.Doctor.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLDiagonistice.Application.IService.IDoctor
{
    public interface IDoctorService
    {
        public Task<ResponseModel<List<DoctorDto>>> GetAllDoctorList();
        public Task<ResponseModel<int>> CreateOrUpdateDoctor(DoctorDto doctorDto);
        public Task<ResponseModel<DoctorDto>> GetDoctorById(int id);
        public Task<ResponseModel<bool>> DeleteDoctorById(int id);
    }
}
