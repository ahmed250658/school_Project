using FluentValidation;
using Microsoft.Extensions.Localization;
using school_Project.Core.Features.Email.Command.Models;
using school_Project.Core.Shared;
using school_Project.Service.Abstracts;

namespace school_Project.Core.Features.Email.Command.Vaildator
{
    public class SendEmailVaildator : AbstractValidator<SendEmailCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        #endregion
        #region Constructors
        public SendEmailVaildator(IStudentService studentService, IStringLocalizer<SharedResource> stringLocalizer, IDepartmentService departmentService)
        {
            _stringLocalizer = stringLocalizer;
        }
        public SendEmailVaildator()
        {
            ApplyValidationRoles();
            ApplyCustomValidationRoles();
        }
        #endregion
        #region Actions
        public void ApplyValidationRoles()
        {
            RuleFor(x => x.Email).
                NotEmpty().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]).
                NotNull().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]);

            RuleFor(x => x.Message).
              NotEmpty().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]).
              NotNull().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]);

        }
        public void ApplyCustomValidationRoles()
        {

        }
        #endregion

    }
}
