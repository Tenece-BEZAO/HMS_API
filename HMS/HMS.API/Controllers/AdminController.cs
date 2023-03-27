using HMS.BLL.Interfaces;
using HMS.DAL.Dtos.Reponses;
using HMS.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static HMS.DAL.Dtos.Requests.AuthenticationRequest;

namespace HMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [Authorize(Policy = "AdminPolicy")]
        [Route("roles/readall")]
        [HttpGet]
        public async Task<IActionResult> GetRolesAsync()
        {
            ResponseStatus response;
            try
            {
                var roles = await _adminService.GetRolesAsync();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                response = SetResponse(400, ex.Message, "", "");
                return BadRequest(response);
            }
        }

        [Authorize(Policy = "AdminPolicy")]
        [Route("users/readall")]
        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            ResponseStatus response;
            try
            {
                var users = await _adminService.GetUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                response = SetResponse(400, ex.Message, "", "");
                return BadRequest(response);
            }
        }
        [Authorize("Admin")]
        [Route("post/role/create")]
        [HttpPost]
        public async Task<IActionResult> PostRoleAsync(ApplicationRole role)
        {
            ResponseStatus response;
            try
            {
                IdentityRole roleInfo = new IdentityRole()
                {
                    Name = role.Name,
                    //NormalizedName = role.NormalizedName
                };
                var res = await _adminService.CreateRoleAsync(roleInfo);
                if (!res)
                {
                    response = SetResponse(500, "Role Registration Failed", "", "");
                    return StatusCode(500, response);
                }
                response = SetResponse(200, $"{role.Name} is Created sussessfully", "", "");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = SetResponse(400, ex.Message, "", "");
                return BadRequest(response);
            }
        }
        [Route("post/register/user")]
        [HttpPost]
        public async Task<IActionResult> RegisterUserAsync(RegisterDto user)
        {
            ResponseStatus response;
            try
            {
                var res = await _adminService.RegisterUserAsync(user);
                if (!res)
                {
                    response = SetResponse(500, "User Registration Failed", "", "");
                    return StatusCode(500, response);
                }
                response = SetResponse(200, $"User {user.Email} is Created sussessfully","","");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = SetResponse(400, ex.Message, "", "");
                return BadRequest(response);
            }
        }

        [Authorize(Policy = "AdminPolicy")]
        [Route("post/activate/user")]
        [HttpPost]
        public async Task<IActionResult> ActivateUserAsync(UserRole user)
        {
            ResponseStatus response;
            try
            {
                var res = await _adminService.AssignRoleToUserAsync(user);
                if (!res)
                {
                    response = SetResponse(500, "Role is not assigned to user", "", "");
                    return StatusCode(500, response);
                }
                response = SetResponse(200, "Role is sussessfully assigned to user", "", "");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = SetResponse(400, ex.Message, "", "");
                return BadRequest(response);
            }
        }
        private ResponseStatus SetResponse(int code, string message, string token, string role)
        {
            ResponseStatus response = new ResponseStatus()
            {
                StatusCode = code,
                Message = message,
                Token = token,
                Role = role
            };
            return response;
        }
    }
}
    

