using System.Threading.Tasks;
using AdlerLing.AccountService.Core.DTO;
using AdlerLing.AccountService.Core.Enums;
using AdlerLing.AccountService.Infrustructure.Service.Interfaces;
using AdlerLing.AccountService.WebApi.Infra;
using AdlerLing.AccountService.WebApi.Model.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace AdlerLing.AccountService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService,
            IStringLocalizer<SharedErrorResource> localizer) : base(localizer)
        {
            _roleService = roleService;
        }

        [HttpPost]
        [Route("CreateRole")]
        public async Task<ApiResponse> CreateRole([FromBody]RoleModel role)
        {
            var res = await _roleService.CreateRole(new CreateRoleDTO { Name = role.Name });

            if (res.Status == ResultStatusEnum.Failure)
            {
                return CreateFailedResponse(res);
            }

            return CreateSuccessResponse(res);
        }
    }
}