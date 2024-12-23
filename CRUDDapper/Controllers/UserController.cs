using CRUDDapper.Dto;
using CRUDDapper.Models;
using CRUDDapper.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CRUDDapper.Controllers
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


        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var users = await _userService.GetUsers();
            if (users.Status == false)
            {
                return NotFound(users);
            }
            return Ok(users);
        }

        [HttpGet("GetUserById/{Id}")]
        public async Task<ActionResult> GetUserById(int Id)
        {
            var user = await _userService.GetUserById(Id);
            if (user.Status == false)
            {
                return NotFound(user);
            }
            return Ok(user);

        }
        [HttpPost]
        public async Task<ActionResult> AddUser(IncludeUserDto newUser)
        {
            var NewUser = await _userService.AddUser(newUser);
          
            if (NewUser.Status == false)
            {
                return BadRequest(NewUser);
            }
            return Ok(NewUser);
        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult> UpdateUser(UserEditDto UserEdit)
        {
            var user = await _userService.UserEdit(UserEdit);
            if(user == null)
            {
                return BadRequest(user);
            }  
            return Ok(user);
        }

        [HttpDelete("DeleteUser{Id}")]
        public async Task<IActionResult> RemoveUser(int Id)
        {
            var user = await _userService.UserRemove(Id);
            if (user == null)
            {
                return BadRequest(user);
            }
            return Ok(user);
        }
    }
}
