using GLDiagonistice.Application.Service.PatientAppointmentService.Dto;

namespace GLDiagonistice.Application.IRepository
{
    public interface IPatientAppointmentRepository
    {
        public Task<int> SaveAndUpdatePatientInformation(PatientDto patientDto );
        public Task<PatientDto> GetPatientInfoById(int id);
        public Task<int> SaveAndUpdateAppointmentDto(AppointmentDto appointmentDto);
        public Task<AppointmentDto> GetAppointmentById(int id);
        
        public Task<List<PatientAppointmentDto>> GetAllTodaysAppointment();
        //public Task<Iq<PatientAppointmentDto>> GetAllAppointment();

    }
}
