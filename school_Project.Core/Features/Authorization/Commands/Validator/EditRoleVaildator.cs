using FluentValidation;
using Microsoft.Extensions.Localization;
using school_Project.Core.Features.Authorization.Commands.Models;
using school_Project.Core.Shared;

namespace school_Project.Core.Features.Authorization.Commands.Validator
{
    public class EditRoleVaildator : AbstractValidator<EditRoleCommand>
    {

        #region fields
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        #endregion
        #region Constructor
        public EditRoleVaildator(IStringLocalizer<SharedResource> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }
        public EditRoleVaildator()
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

            RuleFor(x => x.Name).
              NotEmpty().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]).
              NotNull().WithMessage(_stringLocalizer[SharedREsourceKeys.Required]);
        }

        public void ApplyCustomValidationRoles()
        {

        }
        #endregion

    }
}
