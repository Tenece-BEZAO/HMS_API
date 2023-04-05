using AutoMapper;
using FluentValidation;
using HMS.BLL.Interfaces;
using HMS.DAL.Dtos.Requests;
using HMS.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static HMS.DAL.Dtos.Requests.AuthenticationRequest;

namespace HMS.BLL.Implementation
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateRequest> _validator;

        public UserService(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IMapper mapper, IValidator<UpdateRequest> validator)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _mapper = mapper;
            _validator = validator;
        }

        public string GetUserProfile()
        {
            var result = string.Empty;
            if(_httpContextAccessor.HttpContext is not null)
            {
                result = _httpContextAccessor.HttpContext.User?.Identity?.Name;
                result = _httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.Name).Value ?? result;
            }
            return result;
        }

        public async Task<bool> UpdateUserAsync(string id, UpdateRequest model)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                throw new ArgumentException($"User not found");
            }
            var updatedUser = _mapper.Map(model, user);

            var result = await _userManager.UpdateAsync(updatedUser);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Failed to update user detail");
            }

            return result.Succeeded;
        }


        public async Task<bool> PartialUpdateUserAsync(string userId, JsonPatchDocument<UpdateRequest> patchDoc)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return false;
            }

            var userUpdateDto = _mapper.Map<UpdateRequest>(user);

            patchDoc.ApplyTo(userUpdateDto);

            var validationResult = _validator.Validate(userUpdateDto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            _mapper.Map(userUpdateDto, user);
            var result = await _userManager.UpdateAsync(user);

            return result.Succeeded;
        }

        
        public async Task<AppUserDto> GetUserByIdAsync(string userId)
        {
            var userfetch = await _userManager.FindByIdAsync(userId);

            if (userfetch == null) throw new KeyNotFoundException("User not found");
            var user = _mapper.Map<AppUserDto>(userfetch);
            
            return user;
        }


        public async Task<IEnumerable<AppUser>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            return users;
        }


        public async Task<bool> DeleteAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var result = await _userManager.DeleteAsync(user);
            return true;
        }
    }
}
