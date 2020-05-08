using Microsoft.AspNetCore.Mvc;
using AdlerLing.AccountService.Infrustructure.Service.Interfaces;
using System.Threading.Tasks;
using AdlerLing.AccountService.Core.Enums;

namespace AdlerLing.AccountService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : BaseController
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> CreateUser(string email)
        {
            var res = await _userService.CreateUser(new Core.DTO.CreateUserDTO { Email = email, Password = "12345" });

            if (res.Status == ResultStatusEnum.Failure)
            {

            }

            return null;
        }
    }
}