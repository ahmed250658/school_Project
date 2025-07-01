using FluentValidation;
using Microsoft.Extensions.Localization;
using school_Project.Core.Features.Students.Commands.Models;
using school_Project.Core.Shared;
using school_Project.Service.Abstracts;

namespace school_Project.Core.Features.Students.Commands.Vaildator
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        private readonly IDepartmentService _departmentService;

        #endregion
        #region Constructors
        public AddStudentValidator(IStudentService studentService, IStringLocalizer<SharedResource> stringLocalizer, IDepartmentService departmentService)
        {
            _studentService = studentService;
            _stringLocalizer = stringLocalizer;
            _departmentService = departmentService;
        }
        public AddStudentValidator()
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
                MaximumLength(100).WithMessage(_stringLocalizer[SharedREsourceKeys.MaxLengthis100]);

            RuleFor(x => x.Address).
               NotEmpty().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]).
               NotNull().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]).
               MaximumLength(100).WithMessage(_stringLocalizer[SharedREsourceKeys.MaxLengthis100]);

            RuleFor(x => x.DepartmentId).
              NotEmpty().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]).
              NotNull().WithMessage(_stringLocalizer[SharedREsourceKeys.NotEmpty]);

        }
        public void ApplyCustomValidationRoles()
        {
            RuleFor(x => x.NameAr)
                .MustAsync(async (key, CollectionToken) => !await _studentService.IsNameArExist(key))
                .WithMessage(_stringLocalizer[SharedREsourceKeys.IsExist]);
            RuleFor(x => x.NameEn)
               .MustAsync(async (key, CollectionToken) => !await _studentService.IsNameEnExist(key))
               .WithMessage(_stringLocalizer[SharedREsourceKeys.IsExist]);
            RuleFor(x => x.DepartmentId)
              .MustAsync(async (key, CollectionToken) => await _departmentService.IsDepartmentIdExist(key))
              .WithMessage(_stringLocalizer[SharedREsourceKeys.DepartmentIdNotIsExist]);

        }
        #endregion

    }
}
