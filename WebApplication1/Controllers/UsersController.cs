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
            var users = _userService.FindAll();
            return Ok(users);
        }

        [HttpPost("Save")]
        public IActionResult Save(Users entity)
        {
            if (entity == null)
            {
                return BadRequest("Invalid user data."); // Retorne erro se os dados forem inválidos
            }

            _userService.Create(entity);
            return Ok(); // Retorne a resposta apropriada
        }
        
        [HttpPost("Edit")]
        public IActionResult Edit(Users entity)
        {
            if (entity == null)
            {
                return BadRequest("Invalid user data."); // Retorne erro se os dados forem inválidos
            }

            _userService.Update(entity);
            return Ok(); // Retorne a resposta apropriada
        }


    }
}
