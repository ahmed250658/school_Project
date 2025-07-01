using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using school_Project.Data.Entities;
using school_Project.Infrastructure.Data;
using school_Project.Infrastructure.Repository.Abstract;
using school_Project.Infrastructure.Repository.Abstract.Function;
using school_Project.Service.Abstracts;

namespace school_Project.Service.Impelementions
{
    public class InstructorService : IInstructorService
    {
        #region Fields
        private readonly IInstructorRepository _instructorRepository;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IInstructorFunctionsRepository _instructorFunctionsRepository;
        private readonly IFileService _fileService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion
        #region Constructor
        public InstructorService(IInstructorRepository instructorRepository, ApplicationDbContext applicationDbContext, IInstructorFunctionsRepository instructorFunctionsRepository, IFileService fileService, IHttpContextAccessor httpContextAccessor)
        {
            _instructorRepository = instructorRepository;
            _applicationDbContext = applicationDbContext;
            _fileService = fileService;
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion
        #region Handle Function 
        public async Task<decimal> GetSalarySummationOfInstructor()
        {
            decimal result = 0;
            result = _instructorFunctionsRepository.GetSalarySummationOfInstructor("select dbo.GetSalarySummation()");
            return result;

        }
        public async Task<bool> IsNameArExist(string name)
        {
            // check if the name of student is found
            var stud = _instructorRepository.GetTableNoTracking().Where(x => x.ENameAr.Equals(name)).FirstOrDefault();
            if (stud == null) return false;
            return true;
        }
        public async Task<bool> IsNameEnExist(string name)
        {
            // check if the name of student is found
            var stud = _instructorRepository.GetTableNoTracking().Where(x => x.ENameEn.Equals(name)).FirstOrDefault();
            if (stud == null) return false;
            return true;
        }

        public async Task<bool> IsNameArExistExludeSelf(string nameAr, int id)
        {
            // check if the name of student is found
            var stud = await _instructorRepository.GetTableNoTracking().Where(x => x.ENameAr.Equals(nameAr) & x.InsID != id).FirstOrDefaultAsync();
            if (stud == null) return false;
            return true;
        }
        public async Task<bool> IsNameEnExistExludeSelf(string nameEn, int id)
        {
            // check if the name of student is found
            var stud = await _instructorRepository.GetTableNoTracking().Where(x => x.ENameEn.Equals(nameEn) & x.InsID != id).FirstOrDefaultAsync();
            if (stud == null) return false;
            return true;
        }

        public async Task<string> AddInstructor(Instructor instructor, IFormFile file)
        {
            var context = _httpContextAccessor.HttpContext.Request;
            var baseUrl = context.Scheme + "://" + context.Host;
            var imageUrl = await _fileService.UploadImageAsync("Images / Instructor", file);
            switch (imageUrl)
            {
                case "NoImage": return "NoImage";
                case "FailedToUpload": return "FailedToUpload";
            }
            instructor.Image = baseUrl + imageUrl;
            try
            {
                await _instructorRepository.AddAsync(instructor);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedToAdd";
            }
        }
        #endregion
    }
}
