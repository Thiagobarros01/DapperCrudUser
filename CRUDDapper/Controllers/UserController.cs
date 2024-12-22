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
            if(users.Status == false)
            {
                return NotFound(users);
            }
            return Ok(users);
        }

    }
}
