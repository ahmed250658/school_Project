using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using school_Project.Core.Bases;
using school_Project.Core.Features.Students.Commands.Models;
using school_Project.Core.Shared;
using school_Project.Data.Entities;
using school_Project.Service.Abstracts;

namespace school_Project.Core.Features.Students.Commands.Handler
{
    public class StudentCommandHandler : ResponseHandler,
                                         IRequestHandler<AddStudentCommand, Response<string>>,
                                         IRequestHandler<EditStudentCommand, Response<string>>,
                                         IRequestHandler<DeleteStudentCommand, Response<string>>



    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        #endregion
        #region Constructor
        public StudentCommandHandler(IStudentService studentService, IMapper mapper
             , IStringLocalizer<SharedResource> stringLocalizer) : base(stringLocalizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }
        #endregion
        #region Function Handler
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var studentmapper = _mapper.Map<Student>(request);
            var result = await _studentService.AddAsync(studentmapper);

            if (result == "Success") return Created("");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            // check if student Exits or not
            var studentEdit = await _studentService.GetByIDAsync(request.Id);
            if (studentEdit == null) return NotFound<string>("");
            // mapping from EditStudentCommand To Student
            var studentMapping = _mapper.Map<Student>(request);
            // Edit
            var result = await _studentService.EditAsync(studentMapping);
            if (result == "Success") return Success((string)_stringLocalizer[SharedREsourceKeys.Updated]);
            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            //check if student Exits or not
            var student = await _studentService.GetByIDAsync(request.Id);
            if (student == null) return NotFound<string>();
            //Delete
            var result = await _studentService.DeleteAsync(student);
            if (result == "Success") return Deleted<string>();
            return BadRequest<string>();
        }


        #endregion

    }
}
