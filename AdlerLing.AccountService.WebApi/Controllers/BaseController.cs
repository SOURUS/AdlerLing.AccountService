using AdlerLing.AccountService.WebApi.Infra;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AdlerLing.AccountService.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        public BaseController()
        {

        }

        public ApiResponse CreateSuccessResponse(ApiResponse f)
        {
            return f;
        }
    }
}
