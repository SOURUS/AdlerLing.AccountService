using Microsoft.AspNetCore.Mvc;
using AdlerLing.AccountService.Infrustructure.Service.Interfaces;
using System.Threading.Tasks;

namespace AdlerLing.AccountService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<string> IndexAsync(string email)
        {
            await _userService.CreateUser(new Core.DTO.CreateUserDTO { Email = email, Password = "12345" });
            return null;
        }
    }
}