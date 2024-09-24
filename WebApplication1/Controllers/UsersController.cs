using Microsoft.AspNetCore.Mvc;
using MyWallet.Models;
using MyWallet.Services;
using WebApplication1.Controllers;

namespace MyWallet.Controllers
{
    [ApiController] // Adicione esta anotação
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _userService;
        private readonly ILogger<WeatherForecastController> _logger;

        public UsersController(UsersService userService, ILogger<WeatherForecastController> logger)
        {
            _userService = userService;
            _logger = logger;

        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.ListContent();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult Save(Users entity)
        {
            if (entity == null)
            {
                return BadRequest("Invalid user data."); // Retorne erro se os dados forem inválidos
            }

            _userService.FillContentAsync(entity);
            return CreatedAtAction(nameof(GetAllUsers), new { id = entity.Id }, entity); // Retorne a resposta apropriada
        }
    }
}
