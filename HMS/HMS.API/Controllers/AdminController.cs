using HMS.BLL.Interfaces;
using HMS.DAL.Dtos.Reponses;
using HMS.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Numerics;

namespace HMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        //delete,update,put
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
        [Authorize(Policy = "AdminPolicy")]
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
                    NormalizedName = role.NormalizedName
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
        /*[Route("post/register/user")]
        [HttpPost]
        public async Task<IActionResult> RegisterUserAsync(RegisterUser user)
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
                response = SetResponse(200, $"User {user.Email} is 
                        Created sussessfully","","");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = SetResponse(400, ex.Message, "", "");
                return BadRequest(response);
            }
        }*/

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

       /* [Route("post/auth/user")]
        [HttpPost]
        public async Task<IActionResult> AuthUserAsync(LoginUser user)
        {
            ResponseStatus response = new ResponseStatus();
            try
            {
                var res = await _adminService.AuthUserAsync(user);
                if (res.LoginStatus == LoginStatus.LoginFailed)
                {
                    response = SetResponse(401, "UserName or Password is not found", "", "");
                    return Unauthorized(response);
                }
                if (res.LoginStatus == LoginStatus.NoRoleToUser)
                {
                    response = SetResponse(401, "User is not activated with role. 
                                 Please contact admin on mahesh@myapp.com","","");
                    return Unauthorized(response);
                }
                if (res.LoginStatus == LoginStatus.LoginSuccessful)
                {
                    response = SetResponse(200, "Login Sussessful", res.Token, res.Role);
                    response.UserName = user.UserName;
                    return Ok(response);
                }
                else
                {
                    response = SetResponse(500, "Internal Server Error Occured", "", "");
                    return StatusCode(500, response);
                }
            }
            catch (Exception ex)
            {
                response = SetResponse(400, ex.Message, "", "");
                return BadRequest(response);
            }
        }*/
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
    

