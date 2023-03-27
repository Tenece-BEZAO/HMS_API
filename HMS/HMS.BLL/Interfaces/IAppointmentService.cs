
using HMS.DAL.Dtos.Requests;

namespace HMS.BLL.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentDto>> GetAppointmentsAsync();
        Task<AppointmentDto> GetAppointmentAsync(int id);
        Task<IEnumerable<AppointmentDto>> SearchAppointmentsAsync(string searchTerm);
        Task RejectAppointmentAsync(int appointmentId);
        Task ConfirmAppointmentAsync(int appointmentId);
        Task DeleteAppointmentAsync(int appointmentId);
        Task<AppointmentDto> AddAppointmentAsync(AppointmentDto appointmentDto);
        Task<AppointmentDto> UpdateAppointmentAsync(int appointmentId, AppointmentDto appointmentDto);
    }
}
