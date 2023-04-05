using HMS.DAL.Dtos.Requests;
using HMS.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BLL.Interfaces
{
    public interface IUserService
    {
        string GetUserProfile();
        Task<bool> PartialUpdateUserAsync(string userId, JsonPatchDocument<UpdateRequest> patchDoc);
        Task<bool> DeleteAsync(string userId);
        Task<bool> UpdateUserAsync(string id, UpdateRequest model);
        Task<AppUserDto> GetUserByIdAsync(string userId);
        Task<IEnumerable<AppUser>> GetAllUsersAsync();
    }
}
