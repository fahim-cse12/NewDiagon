using GLDiagonistice.Application.Service.PatientAppointmentService.Dto;

namespace GLDiagonistice.Application.IRepository
{
    public interface IPatientAppointmentRepository
    {
        public Task<int> SaveAndUpdatePatientAppointment(PatientAppointmentDto patientAppointmentDto );
        public Task<PatientAppointmentDto> GetPatientAppointmentById(long id);
        public Task<int> DeletePatientAppointmen(long Id);        
        public Task<IQueryable<PatientAppointmentDto>> GetAllPatientAppointment();

    }
}
