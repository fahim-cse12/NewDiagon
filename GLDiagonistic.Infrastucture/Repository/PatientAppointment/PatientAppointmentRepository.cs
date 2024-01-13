using AutoMapper;
using Dapper;
using GLDiagonistic.Infrastucture.Common;
using GLDiagonistice.Application.IRepository;
using GLDiagonistice.Application.Service.PatientAppointmentService.Dto;
using System.Data;
using System.Diagnostics;

namespace GLDiagonistic.Infrastucture.Repository.PatientAppointment
{
    public class PatientAppointmentRepository : IPatientAppointmentRepository
    {
        private readonly GLDDbContext _dbContext;
        private readonly IDbConnection _dbConnection;
        private readonly IMapper _mapper;
        public PatientAppointmentRepository(GLDDbContext dbContext, IDbConnection dbConnection ,IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
            _dbConnection = dbConnection;   
        }

        public Task<int> DeletePatientAppointmen(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<PatientAppointmentDto>> GetAllPatientAppointment()
        {
            throw new NotImplementedException();
        }

        public async Task<List<PatientAppointmentDto>> GetAllTodaysAppointment()
        {
            try
            {
                var results = await _dbConnection.QueryAsync<PatientAppointmentDto>("AllAppointmentList", commandType: CommandType.StoredProcedure);
                return results.ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public Task<PatientAppointmentDto> GetPatientAppointmentById(long id)
        {
            throw new NotImplementedException();
        }

      

        public async Task<int> SaveAndUpdatePatientAppointment(PatientAppointmentDto patientAppointmentDto)
        {
            try
            {
                var patientAppointment = _mapper.Map<GLDiagonistic.Domain.PatientAppointment>(patientAppointmentDto);
                if(patientAppointmentDto.Id > 0)
                {
                    var appointment = _dbContext.PatientAppointments.Update(patientAppointment);
                    await _dbContext.SaveChangesAsync();
                    return (int)appointment.Entity.Id;
                }
                else
                {
                    var appointment = await _dbContext.PatientAppointments.AddAsync(patientAppointment);
                    await _dbContext.SaveChangesAsync();
                    return (int)appointment.Entity.Id;
                }               

            }
            catch (Exception ex)
            {
                return 0 ;
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        //public async Task<int> SaveAndUpdatePatientInformation(PatientDto patientDto)
        //{
        //    Patient patient = _mapper.Map<Patient>(patientDto);
        //    if(patientDto.Id > 0)
        //    {
        //         _dbContext.Patients.Update(patient);
        //    }
        //    else
        //    {
        //        await _dbContext.Patients.AddAsync(patient);
        //    }
          
        //    await _dbContext.SaveChangesAsync();

        //    return patient.Id;
        //}
    }
}
