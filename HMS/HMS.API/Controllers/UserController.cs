using HMS.BLL.Interfaces;
using HMS.DAL.Dtos.Requests;
using HMS.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace HMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }



        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(string userId, [FromBody] UpdateRequest model)
        {

            var result = await _userService.UpdateUserAsync(userId, model);

            if (!result)
            {
                return NotFound();
            }

            return Ok(new { message = "user updated successfully" });
        }


        [HttpPatch("{userId}")]
        public async Task<IActionResult> PartialUpdateUser(string userId, JsonPatchDocument<UpdateRequest> patchDoc)
        {
            var result = await _userService.PartialUpdateUserAsync(userId, patchDoc);


            if (!result)
            {
                return BadRequest("fail to update");
            }

            return Ok("successfully");
        }



        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _userService.Delete(id);
            return Ok(new { message = "User deleted successfully" });
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(userId);
                return Ok(user);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
    }
}
