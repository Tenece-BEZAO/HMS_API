using HMS.DAL.Dtos.Requests;

namespace HMS.BLL.Interfaces
{
    public interface IPlanService
    {
        Task<IEnumerable<PlanDto>> GetPlansAsync();
        Task<PlanDto> GetPlanByIdAsync(int planId);
        Task<PlanDto> GetPlanByNameAsync(string name);
        Task<PlanDto> NewPlanAsync(PlanDto planDto);
        Task<PlanDto> UpdatePlanAsync(int planId, PlanDto planDto);
        Task DeletePlanAsync(int planId);
    }
}
