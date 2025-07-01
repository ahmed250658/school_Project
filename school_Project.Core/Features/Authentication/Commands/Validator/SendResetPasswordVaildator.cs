using FluentValidation;
using Microsoft.Extensions.Localization;
using school_Project.Core.Features.Authentication.Commands.Models;
using school_Project.Core.Shared;

namespace school_Project.Core.Features.Authentication.Commands.Validator
{
    public class SendResetPasswordVaildator : AbstractValidator<SendResetPasswordCommand>
    {


        #region fields
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        #endregion
        #region Constructor
        public SendResetPasswordVaildator(IStringLocalizer<SharedResource> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }
        public SendResetPasswordVaildator()
        {
            ApplyValidationRoles();
            ApplyCustomValidationRoles();
        }

        #endregion
        #region Handle Function

        public void ApplyValidationRoles()
        {
            RuleFor(x => x.Email).
                NotEmpty().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]).
                NotNull().WithMessage(_stringLocalizer[SharedREsourceKeys.Required]);
        }

        public void ApplyCustomValidationRoles()
        {

        }
        #endregion

    }
}
