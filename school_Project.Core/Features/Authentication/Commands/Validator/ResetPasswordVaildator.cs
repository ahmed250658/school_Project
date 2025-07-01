using FluentValidation;
using Microsoft.Extensions.Localization;
using school_Project.Core.Features.Authentication.Commands.Models;
using school_Project.Core.Shared;

namespace school_Project.Core.Features.Authentication.Commands.Validator
{
    class ResetPasswordVaildator : AbstractValidator<ResetPasswordCommand>
    {


        #region fields
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        #endregion
        #region Constructor
        public ResetPasswordVaildator(IStringLocalizer<SharedResource> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }
        public ResetPasswordVaildator()
        {
            ApplyValidationRoles();
            ApplyCustomValidationRoles();
        }

        #endregion
        #region Handle Function

        public void ApplyValidationRoles()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedREsourceKeys.Required]);
            RuleFor(x => x.Password)
                   .NotEmpty().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty])
                 .NotNull().WithMessage(_stringLocalizer[SharedREsourceKeys.Required]);
            RuleFor(x => x.ConfirmPassword)
                 .Equal(x => x.Password).WithMessage(_stringLocalizer[SharedREsourceKeys.PasswordNotEquelConfrimPassword]);
        }

        public void ApplyCustomValidationRoles()
        {

        }
        #endregion

    }
}
