using Microsoft.AspNetCore.Mvc;
using AdlerLing.AccountService.Infrustructure.Service.Interfaces;
using System.Threading.Tasks;
using AdlerLing.AccountService.Core.Enums;
using AdlerLing.AccountService.WebApi.Infra;
using AdlerLing.AccountService.Core.Transfering;
using AdlerLing.AccountService.WebApi.Model.Request;

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

        [HttpPost]
        [Route("CreateUser")]
        public async Task<Result> CreateUser([FromBody]UserModel user)
        {
            var res = await _userService.CreateUser(new Core.DTO.CreateUserDTO { Email = user.Email, Password = user.Password });

            if (res.Status == ResultStatusEnum.Failure)
            {
                return res;
            }

            return res;
        }
    }
}