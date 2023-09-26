using GLDiagonistice.Application.Service.Doctor.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLDiagonistice.Application.IRepository
{
    public interface IDoctorRepository
    {
        public Task<List<DoctorDto>> GetAllDoctor();
    }
}
