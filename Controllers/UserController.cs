using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using StundenplanApp.Models;
using StundenplanApp.Services;

namespace StundenplanApp.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        public readonly IUserService userService;
        public UserController(IUserService userInterface) {
            userService = userInterface;
        }
        [HttpPost]
        public async Task<IActionResult> createUser(Users newUser)
        {
            return Ok(await userService.createUser(newUser));
        }
        [HttpDelete("{userID}")]
        public async Task<IActionResult> deleteUser(int userID)
        {
            return Ok(await userService.deleteUser(userID));
        }
        [HttpGet("{userID}")]
        public async Task<IActionResult> getUser(int userID)
        {
            return Ok(await userService.getUser(userID));
        }
        [HttpPut]
        public async Task<IActionResult> editUser(Users userToEdit)
        {
            return Ok(await userService.editUser(userToEdit));
        }
    }
}
