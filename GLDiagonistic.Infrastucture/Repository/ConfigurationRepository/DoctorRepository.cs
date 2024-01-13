using AutoMapper;
using GLDiagonistic.Infrastucture.Common;
using GLDiagonistice.Application.IRepository;
using GLDiagonistice.Application.Service.ConfigurationService.Dto;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace GLDiagonistic.Infrastucture.Repository.ConfigurationRepository
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
                    List<DoctorDto> resultList = new List<DoctorDto>();
                    foreach (var item in doctorList)
                    {
                        var doctor = new DoctorDto
                        {
                            Id = item.Id,
                            DoctorName = item.DoctorName,
                            ContactNumber = item.ContactNumber,
                            Gender = item.Gender,
                            SpecialistOn = item.SpecialistOn,
                            Status = item.Status,
                            DoctorsFee = JsonConvert.DeserializeObject<Fees>(item.DoctorsFee.ToString()),
                            CreatedAt = item.CreatedAt,
                            CreatedBy = item.CreatedBy,
                            ScheduleDays = item.ScheduleDays,
                            UpdatedAt = item.UpdatedAt,
                            UpdateddBy = item.UpdateddBy
                        };

                        resultList.Add(doctor);
                    }

                    return resultList;
                }

                return new List<DoctorDto>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

    }
}
