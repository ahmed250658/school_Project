using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using school_Project.Core.Bases;
using school_Project.Core.Features.Students.Queries.Dtos;
using school_Project.Core.Features.Students.Queries.Models;
using school_Project.Core.Pagination;
using school_Project.Core.Shared;
using school_Project.Service.Abstracts;

namespace school_Project.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler,
                                      IRequestHandler<GetStudentListQuery, Response<List<GetStudentListResponse>>>,
                                      IRequestHandler<GetStudentByIDQuery, Response<GetSingleStudent>>,
                                      IRequestHandler<GetStudentPagenatedQuery, PaginatedResult<GetStudentPaginatedResponse>>
    {
        #region Fields
        public readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        #endregion

        #region Constructure
        public StudentQueryHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<SharedResource> stringLocalizer) : base(stringLocalizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }
        #endregion

        #region Handle Function

        public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentlist = await _studentService.GetStudentListAsync();
            var studentlistmapper = _mapper.Map<List<GetStudentListResponse>>(studentlist);
            var result = Success(studentlistmapper);
            result.Meta = new { Count = studentlistmapper.Count };
            return result;
        }

        public async Task<Response<GetSingleStudent>> Handle(GetStudentByIDQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIDWithIncludeAsync(request.Id);
            if (student == null)
                return NotFound<GetSingleStudent>(_stringLocalizer[SharedREsourceKeys.NotFound]);
            var result = _mapper.Map<GetSingleStudent>(student);
            return Success(result);
        }

        public async Task<PaginatedResult<GetStudentPaginatedResponse>> Handle(GetStudentPagenatedQuery request, CancellationToken cancellationToken)
        {
            //Expression<Func<Student, GetStudentPaginatedListResponse>> expression = e => new GetStudentPaginatedListResponse(e.StudID, e.Localize(e.NameAr, e.NameEn), e.Address, e.Department.Localize(e.Department.DNameAr, e.Department.DNameEn));
            var FilterQuery = _studentService.FilterStudentPaginationQuerable(request.OrderBy, request.Search);
            var PaginatedList = await _mapper.ProjectTo<GetStudentPaginatedResponse>(FilterQuery).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            PaginatedList.Meta = new { Count = PaginatedList.Data.Count() };
            return PaginatedList;
        }
        #endregion
    }
}
