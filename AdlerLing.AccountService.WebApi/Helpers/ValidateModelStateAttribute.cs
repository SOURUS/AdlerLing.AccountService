﻿using AdlerLing.AccountService.WebApi.Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Net;

namespace AdlerLing.AccountService.WebApi.Helpers
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.Where(v => v.Errors.Count > 0)
                        .SelectMany(v => v.Errors)
                        .Select(v => v.ErrorMessage)
                        .ToList();

                var responseObj = new ApiResponse
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    ErrorMessages = errors
                };

                context.Result = new JsonResult(responseObj)
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
        }
    }
}
