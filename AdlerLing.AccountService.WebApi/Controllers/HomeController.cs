using Microsoft.AspNetCore.Mvc;
using AdlerLing.AccountService.Infrustructure.Service.Interfaces;
using System.Threading.Tasks;
using AdlerLing.AccountService.Core.Enums;
using AdlerLing.AccountService.WebApi.Infra;
using AdlerLing.AccountService.WebApi.Model.Request;
using AdlerLing.AccountService.Core.DTO;
using Microsoft.Extensions.Localization;

namespace AdlerLing.AccountService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : BaseController
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService, 
            IStringLocalizer<SharedErrorResource> localizer) : base(localizer)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<ApiResponse> CreateUser([FromBody]UserModel user)
        {
            var res = await _userService.CreateUser(new CreateUserDTO { Email = user.Email, Password = user.Password });

            if (res.Status == ResultStatusEnum.Failure)
            {
                return CreateFailedResponse(res);
            }

            return CreateSuccessResponse(res);
        }
    }
}