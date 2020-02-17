using AdlerLing.AccountService.Core.Settings;
using AdlerLing.AccountService.Infrustructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AdlerLing.AccountService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public HomeController(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        public string Index()
        {
            userRepository.Create(new Core.DTO.CreateUserDTO { Email= "sour47@yandex.ru", Password = "12345" });
            return null;
        }
    }
}