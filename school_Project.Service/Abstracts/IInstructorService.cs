using Microsoft.AspNetCore.Http;
using school_Project.Data.Entities;

namespace school_Project.Service.Abstracts
{
    public interface IInstructorService
    {
        public Task<decimal> GetSalarySummationOfInstructor();
        public Task<bool> IsNameArExist(string name);
        public Task<bool> IsNameEnExist(string name);
        public Task<bool> IsNameArExistExludeSelf(string nameAr, int id);
        public Task<bool> IsNameEnExistExludeSelf(string nameEn, int id);
        public Task<string> AddInstructor(Instructor instructor, IFormFile file);
    }
}
