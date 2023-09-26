using GLDiagonistice.Application.IRepository;
using GLDiagonistice.Application.IService.IDoctor;
using GLDiagonistice.Application.Service.Common;
using GLDiagonistice.Application.Service.Doctor.Dto;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace GLDiagonistice.Application.Service.Doctor
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IHttpContextAccessor _httpcontext;
        public DoctorService(IDoctorRepository doctorRepository , IHttpContextAccessor httpcontext)
        {
            this._doctorRepository = doctorRepository;
            this._httpcontext = httpcontext;    
        }

        private ResponseModel<T> CreateResponse<T>(bool status, T? data, string message, List<string>? erros)
        {
            return new ResponseModel<T>
            {
                Success = status,
                Data = data,
                Message = message,
                Errors = erros
            };
        }
        public Task<ResponseModel<int>> CreateOrUpdateDoctor(DoctorDto doctorDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<bool>> DeleteDoctorById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<DoctorDto>>> GetAllDoctorList()
        {
            try
            {
                var doctorList = await _doctorRepository.GetAllDoctor();
                if (doctorList.Any())
                {
                    return CreateResponse(true, doctorList, "", null);
                }

                return CreateResponse(true, doctorList, "No data found", null); 

            }
            catch (Exception ex)
            {
                return CreateResponse<List<DoctorDto>> (false, null, ex.Message, null);
            }
        }

        public Task<ResponseModel<DoctorDto>> GetDoctorById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
