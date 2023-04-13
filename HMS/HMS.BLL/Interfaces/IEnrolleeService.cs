using HMS.DAL.Dtos.Requests;

namespace HMS.BLL.Interfaces
{
    public interface IEnrolleeService
    {
        Task<IEnumerable<EnrolleeDto>> GetEnrolleesAsync();
        Task<EnrolleeDto> GetEnrolleeAsync(string enrolleeId);
        Task<string> CreateEnrolleeAsync(EnrolleeDto enrolleeDTO);
        Task SubscribeToPlanAsync(string enrolleeId, int planId);
        Task<PlanDto> GetEnrolleePlanAsync(string enrolleeId);
        Task UnsubscribeFromPlanAsync(string enrolleeId);
        Task UpdateEnrolleeAsync(string enrolleeId, EnrolleeDto enrolleeDTO);
        Task DeleteEnrolleeAsync(string enrolleeId);
    }
}
