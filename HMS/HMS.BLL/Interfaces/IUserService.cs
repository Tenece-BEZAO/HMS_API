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
        Task Delete(string userId);
        Task<bool> UpdateUserAsync(string id, UpdateRequest model);
        Task<AppUser> GetUserByIdAsync(string userId);
        Task<IEnumerable<AppUser>> GetAllUsersAsync();
    }
}
