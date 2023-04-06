using HMS.DAL.Dtos.Requests;
using HMS.DAL.Entities;
using Microsoft.AspNetCore.JsonPatch;


namespace HMS.BLL.Interfaces
{
    public interface IUserService
    {
        Task <string> GetUserProfile();
        Task<bool> PartialUpdateUserAsync(string userId, JsonPatchDocument<UpdateRequest> patchDoc);
        Task<bool> DeleteAsync(string userId);
        Task<bool> UpdateUserAsync(string id, UpdateRequest model);
        Task<AppUserDto> GetUserByIdAsync(string userId);
        Task<IEnumerable<AppUser>> GetAllUsersAsync();
    }
}
