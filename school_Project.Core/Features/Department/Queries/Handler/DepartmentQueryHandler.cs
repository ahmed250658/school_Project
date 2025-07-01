using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using school_Project.Core.Bases;
using school_Project.Core.Features.Department.Queries.Dtos;
using school_Project.Core.Features.Department.Queries.Models;
using school_Project.Core.Pagination;
using school_Project.Core.Shared;
using school_Project.Data.Entities;
using school_Project.Data.Entities.Procedures;
using school_Project.Service.Abstracts;
using Serilog;
namespace school_Project.Core.Features.Department.Queries.Handler
{
    public class DepartmentQueryHandler : ResponseHandler,
                                           IRequestHandler<GetDepartmentByIDQuery, Response<GetDepartmentByIDQueryResponse>>,
                                           IRequestHandler<GetDepartmentStudentCount, Response<List<GetDepartmentStudentCountResponse>>>,
                                           IRequestHandler<GetDepartmentStudentCountByIQuery, Response<GetDepartmentStudentCountByIQueryReposne>>
    {
        #region Fields
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        public readonly IStudentService _studentService;
        #endregion

        #region Constructor
        public DepartmentQueryHandler(IStringLocalizer<SharedResource> stringLocalizer, IDepartmentService departmentService, IMapper mapper, IStudentService studentService) : base(stringLocalizer)
        {
            _departmentService = departmentService;
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _studentService = studentService;
        }
        #endregion

        #region Handle Function
        public async Task<Response<GetDepartmentByIDQueryResponse>> Handle(GetDepartmentByIDQuery request, CancellationToken cancellationToken)
        {
            // Service Get Department BY Id
            var response = await _departmentService.GetDepartmentByID(request.Id);
            //Check if Department is Not Exist
            if (response == null)
                return NotFound<GetDepartmentByIDQueryResponse>();
            //Mapping
            var mapper = _mapper.Map<GetDepartmentByIDQueryResponse>(response);
            //Pagination
            Expression<Func<Student, StudentResponse>> expression = e => new StudentResponse(e.StudID, e.GetLocalize(e.NameAr, e.NameEn));
            var student = _studentService.GetStudentByDepartmentQuerable(request.Id);
            var Studentpaginated = await student.Select(expression).ToPaginatedListAsync(request.StudentPageNumber, request.StudentPageSize);
            mapper.StudentList = Studentpaginated;
            Log.Information("Get Department By Id {Id} Successfully", request.Id);
            // Return Response
            return Success(mapper);

        }
        public async Task<Response<List<GetDepartmentStudentCountResponse>>> Handle(GetDepartmentStudentCount request, CancellationToken cancellationToken)
        {
            var result = await _departmentService.GetViewDepartmentAsync();
            var mappre = _mapper.Map<List<GetDepartmentStudentCountResponse>>(result);
            return Success<List<GetDepartmentStudentCountResponse>>(mappre);
        }

        public async Task<Response<GetDepartmentStudentCountByIQueryReposne>> Handle(GetDepartmentStudentCountByIQuery request, CancellationToken cancellationToken)
        {
            var parameter = _mapper.Map<DepartmentProcParameter>(request);
            var process = await _departmentService.GetDepartmentProcAsync(parameter);
            var result = _mapper.Map<GetDepartmentStudentCountByIQueryReposne>(process.FirstOrDefault());
            return Success(result);
        }
        #endregion


    }

}
