using AdlerLing.AccountService.Core.Transfering;
using AdlerLing.AccountService.WebApi.Infra;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Net;

namespace AdlerLing.AccountService.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        public readonly IStringLocalizer<SharedErrorResource> _localizer;
        public readonly IMapper _mapper;

        public BaseController(IStringLocalizer<SharedErrorResource> localizer, IMapper mapper)
        {
            _mapper = mapper;
            _localizer = localizer;
        }

        public ApiResponse CreateSuccessResponse(Result serviceResult)
        {
            return ApiResponse.CreateSuccess(HttpStatusCode.OK, serviceResult);
        }

        public ApiResponse CreateSuccessResponse(object serviceResult)
        {
            return ApiResponse.CreateSuccess(HttpStatusCode.OK, serviceResult);
        }

        public ApiResponse CreateFailedResponse(Result serviceResult)
        {
            List<string> errorMessages = new List<string>();

            if (serviceResult.ErrorMessages.Count > 0)
            {
                foreach (var r in serviceResult.ErrorMessages)
                {
                    errorMessages.Add(_localizer[r.ToString()]);
                }
            }

            if (serviceResult.Exception != null)
            {
                errorMessages.Add(_localizer["Exception_Error"]);
            }

            return ApiResponse.CreateFailure(HttpStatusCode.BadRequest, errorMessages);
        }
    }
}
