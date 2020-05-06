using AdlerLing.AccountService.Infrustructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public string Index(string email)
        {
            userRepository.Create(new Core.DTO.CreateUserDTO { Email= email, Password = "12345" });
            return null;
        }
    }
}