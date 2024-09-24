using Microsoft.AspNetCore.Mvc;
using MyWallet.Services;

namespace MyWallet.Controllers
{
    public class UsersController : ControllerBase
    {
        public readonly UsersService _userService;

        public UsersController(UsersService userService)
        {
            _userService = userService;
        }

        public IActionResult GetAllUsers()
        {
            var users = _userService.ListContent();
            return Ok(users);
        }
    }
}
