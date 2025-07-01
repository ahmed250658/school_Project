using FluentValidation;
using Microsoft.Extensions.Localization;
using school_Project.Core.Features.Authorization.Commands.Models;
using school_Project.Core.Shared;
using school_Project.Service.Abstracts;

namespace school_Project.Core.Features.Authorization.Commands.Validator
{
    public class AddRoleVaildator : AbstractValidator<AddRoleCommand>
    {

        #region fields
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        private readonly IAuthorizationService _authroziationService;
        #endregion
        #region Constructor
        public AddRoleVaildator(IStringLocalizer<SharedResource> stringLocalizer, IAuthorizationService authroziationService)
        {
            _stringLocalizer = stringLocalizer;
            _authroziationService = authroziationService;
        }
        public AddRoleVaildator()
        {
            ApplyValidationRoles();
            ApplyCustomValidationRoles();
        }

        #endregion
        #region Handle Function

        public void ApplyValidationRoles()
        {
            RuleFor(x => x.RoleName).
              NotEmpty().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]).
              NotNull().WithMessage(_stringLocalizer[SharedREsourceKeys.Required]);
        }

        public void ApplyCustomValidationRoles()
        {
            RuleFor(x => x.RoleName)
                .MustAsync(async (key, CollectionToken) => !await _authroziationService.IsRoleExsitByName(key))
                .WithMessage(_stringLocalizer[SharedREsourceKeys.IsExist]);
        }
        #endregion

    }
}
