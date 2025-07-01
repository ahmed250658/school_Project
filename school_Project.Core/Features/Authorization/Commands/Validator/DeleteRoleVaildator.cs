using FluentValidation;
using Microsoft.Extensions.Localization;
using school_Project.Core.Features.Authorization.Commands.Models;
using school_Project.Core.Shared;
using school_Project.Service.Abstracts;

namespace school_Project.Core.Features.Authorization.Commands.Validator
{
    public class DeleteRoleVaildator : AbstractValidator<DeleteRoleCommand>
    {
        #region fields
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        public readonly IAuthorizationService _authorizationService;
        #endregion
        #region Constructor
        public DeleteRoleVaildator(IStringLocalizer<SharedResource> stringLocalizer, IAuthorizationService authorizationService)
        {
            _stringLocalizer = stringLocalizer;
            _authorizationService = authorizationService;
        }
        public DeleteRoleVaildator()
        {
            ApplyValidationRoles();
            ApplyCustomValidationRoles();
        }

        #endregion
        #region Handle Function

        public void ApplyValidationRoles()
        {
            RuleFor(x => x.Id).
              NotEmpty().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]).
              NotNull().WithMessage(_stringLocalizer[SharedREsourceKeys.Required]);

        }

        public void ApplyCustomValidationRoles()
        {
            //    RuleFor(x => x.Id)
            //        .MustAsync(async (key, CollectionToken) => !await _authorizationService.IsRoleExsitById(key))
            //        .WithMessage(_stringLocalizer[SharedREsourceKeys.RoleIsNotExist]);
        }
        #endregion
    }
}
