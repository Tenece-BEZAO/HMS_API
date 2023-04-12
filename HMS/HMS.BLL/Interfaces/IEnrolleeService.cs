using HMS.DAL.Dtos.Requests;

namespace HMS.BLL.Interfaces
{
    public interface IEnrolleeService
    {
        Task<IEnumerable<EnrolleeDto>> GetEnrolleesAsync();
        Task<EnrolleeDto> GetEnrolleeAsync(int enrolleeId);
        Task<int> CreateEnrolleeAsync(EnrolleeDto enrolleeDTO);
        Task SubscribeToPlanAsync(int enrolleeId, int planId);
        Task<PlanDto> GetEnrolleePlanAsync(int enrolleeId);
        Task UnsubscribeFromPlanAsync(int enrolleeId);
        Task UpdateEnrolleeAsync(int enrolleeId, EnrolleeDto enrolleeDTO);
        Task DeleteEnrolleeAsync(int enrolleeId);
    }
}
