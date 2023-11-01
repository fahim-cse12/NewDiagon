using AutoMapper;
using GLDiagonistic.Infrastucture.Common;
using GLDiagonistice.Application.IRepository;
using GLDiagonistice.Application.Service.PatientAppointmentService.Dto;
using System.Data;

namespace GLDiagonistic.Infrastucture.Repository.PatientAppointment
{
    public class PatientInvestigationRepository : IPaitentInvestigationRepository
    {
        private readonly GLDDbContext _dbContext;
        private readonly IDbConnection _dbConnection;
        private readonly IMapper _mapper;
        public PatientInvestigationRepository(GLDDbContext dbContext, IDbConnection dbConnection, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
            _dbConnection = dbConnection;
        }
        public Task<long> CreateOrUpdatePatienInvestigation(PatientInvestigationDto patientInvestigationDto)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<PatientInvestigationDto>> GetAllPatientInvestigationByAppointment(long appointmentId)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<PatientInvestigationDto>> GetAllPatientInvestigationByDateRange(DateTime fromDate, DateTime toDate)
        {
            throw new NotImplementedException();
        }
    }
}
