using HMS.BLL.Interfaces;
using HMS.DAL.Dtos.Requests;
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


        [HttpGet("getUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }


        [HttpGet("getUser")]
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


        [HttpPut("updateUser")]
        public async Task<IActionResult> UpdateUser(string userId, [FromBody] UpdateRequest model)
        {

            var result = await _userService.UpdateUserAsync(userId, model);

            if (!result)
            {
                return NotFound();
            }

            return Ok(new { message = "user details updated successfully" });
        }


        [HttpPatch("partialUpdateUser")]
        public async Task<IActionResult> PartialUpdateUser(string userId, JsonPatchDocument<UpdateRequest> patchDoc)
        {
            var result = await _userService.PartialUpdateUserAsync(userId, patchDoc);


            if (!result)
            {
                return BadRequest("fail to update");
            }

            return Ok("updated successfully");
        }


        [Authorize]
        [HttpDelete("deactivateUser")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var deletedUser = await _userService.DeleteAsync(id);

            if (!deletedUser)
            {
                return NotFound("User not found, try again");
            }
            return Ok(new { message = "User deactivated successfully" });
        }
    }
}
