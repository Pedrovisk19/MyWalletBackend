using Microsoft.AspNetCore.Mvc;
using MyWallet.Models.Repository;
using MyWallet.Models;
using MyWallet.Services;

namespace MyWallet.Controllers
{
    [ApiController] // Adicione esta anotação
    [Route("[controller]")]
    public class UserMoneyController : ControllerBase
    {
        private readonly UserMoneyService _userMoneyService;

        public UserMoneyController(UserMoneyService userMoneyService)
        {
            _userMoneyService = userMoneyService;

        }

        [HttpGet]
        public List<UserMoney> FindAll()
        {
            return _userMoneyService.FindAll();
        }
    }
}
