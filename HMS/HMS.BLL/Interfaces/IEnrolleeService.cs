using HMS.DAL.Dtos.Requests;

namespace HMS.BLL.Interfaces
{
    public interface IEnrolleeService
    {
        Task<IEnumerable<EnrolleeDTO>> GetEnrolleesAsync();
        Task<EnrolleeDTO> GetEnrolleeAsync(int enrolleeId);
        Task<EnrolleeDTO> NewEnrolleeAsync(EnrolleeDTO enrolleeDTO);
        Task<EnrolleeDTO> UpdateEnrolleeAsync(int enrolleeId, EnrolleeDTO enrolleeDTO);
        Task DeleteEnrolleeAsync(int enrolleeId);
    }
}
