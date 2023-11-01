using GLDiagonistice.Application.Service.PatientAppointmentService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLDiagonistice.Application.IRepository
{
    public interface IPaitentInvestigationRepository
    {
        public Task<IQueryable<PatientInvestigationDto>> GetAllPatientInvestigationByAppointment(long appointmentId);
        public Task<long> CreateOrUpdatePatienInvestigation(PatientInvestigationDto patientInvestigationDto);
        public Task<IQueryable<PatientInvestigationDto>> GetAllPatientInvestigationByDateRange(DateTime fromDate, DateTime toDate);
    }
}
