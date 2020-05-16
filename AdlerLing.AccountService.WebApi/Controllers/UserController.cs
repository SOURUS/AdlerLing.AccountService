using Microsoft.AspNetCore.Mvc;
using AdlerLing.AccountService.Infrustructure.Service.Interfaces;
using System.Threading.Tasks;
using AdlerLing.AccountService.Core.Enums;
using AdlerLing.AccountService.WebApi.Infra;
using AdlerLing.AccountService.WebApi.Model.Request;
using AdlerLing.AccountService.Core.DTO;
using Microsoft.Extensions.Localization;
using AutoMapper;
using System;

namespace AdlerLing.AccountService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService, 
            IStringLocalizer<SharedErrorResource> localizer, IMapper mapper) : base(localizer, mapper)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<ApiResponse> CreateUser([FromBody]UserModel user)
        {
            var res = await _userService.CreateUser(_mapper.Map<UserDTO>(user));

            if (res.Status == ResultStatusEnum.Failure)
            {
                return CreateFailedResponse(res);
            }

            return CreateSuccessResponse(res);
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<ApiResponse> GetUser(Guid userId)
        {
            var res = await _userService.GetUser(userId);

            if (res.Status == ResultStatusEnum.Failure)
            {
                return CreateFailedResponse(res);
            }

            return CreateSuccessResponse(_mapper.Map<UserModel>(res.Data));
        }
    }
}