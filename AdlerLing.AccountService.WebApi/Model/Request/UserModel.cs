using AdlerLing.AccountService.WebApi.Helpers;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;

namespace AdlerLing.AccountService.WebApi.Model.Request
{
    public class UserModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public List<RoleModel> Roles { get; set; } 
    }

    public class UserModelValidator : AbstractValidator<UserModel>
    {
        public UserModelValidator(IStringLocalizer<SharedErrorResource> localizer)
        {
            //RuleFor(x => x.Email).EmailAddress().WithMessage(localizer["UserModel_NotRightFormatEmail"]); ;
            RuleFor(x => x.Password).MinimumLength(6).WithMessage(localizer["UserModel_MinLengthPassword"]);
        }
    }
}