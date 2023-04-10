using HMS.DAL.Dtos.Requests;

namespace HMS.BLL.Interfaces
{
    public interface IEnrolleeService
    {
        Task<IEnumerable<EnrolleeDto>> GetEnrolleesAsync();
        Task<EnrolleeDto> GetEnrolleeAsync(int enrolleeId);
        Task<EnrolleeDto> NewEnrolleeAsync(EnrolleeDto enrolleeDTO);
        Task SetEnrolleePlan(int enrolleeId, int planId);
        Task<PlanDto> GetEnrolleePlan(int enrolleeId);
        Task<EnrolleeDto> UpdateEnrolleeAsync(int enrolleeId, EnrolleeDto enrolleeDTO);
        Task DeleteEnrolleeAsync(int enrolleeId);
    }
}
