using FluentValidation;
using Microsoft.Extensions.Localization;
using school_Project.Core.Features.Students.Commands.Models;
using school_Project.Core.Shared;
using school_Project.Service.Abstracts;

namespace school_Project.Core.Features.Students.Commands.Vaildator
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        #endregion
        #region Constructors
        public EditStudentValidator(IStudentService studentService, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _studentService = studentService;
            _stringLocalizer = stringLocalizer;
        }
        public EditStudentValidator()
        {
            ApplyValidationRoles();
            ApplyCustomValidationRoles();
        }
        #endregion
        #region Actions
        public void ApplyValidationRoles()
        {
            RuleFor(x => x.NameAr).
                NotEmpty().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]).
                NotNull().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]).
                MaximumLength(20).WithMessage(_stringLocalizer[SharedREsourceKeys.MaxLengthis100]);

            RuleFor(x => x.Address).
               NotEmpty().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]).
               NotNull().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]).
               MaximumLength(20).WithMessage(_stringLocalizer[SharedREsourceKeys.MaxLengthis100]);

        }
        public void ApplyCustomValidationRoles()
        {
            RuleFor(x => x.NameAr)
                .MustAsync(async (model, key, CollectionToken) => !await _studentService.IsNameArExistExludeSelf(key, model.Id))
                .WithMessage(_stringLocalizer[SharedREsourceKeys.IsExist]);
            RuleFor(x => x.NameEn)
               .MustAsync(async (model, key, CollectionToken) => !await _studentService.IsNameEnExistExludeSelf(key, model.Id))
               .WithMessage(_stringLocalizer[SharedREsourceKeys.IsExist]);
        }
        #endregion
    }
}
