using school_Project.Data.Entities;
using school_Project.Data.Enums;

namespace school_Project.Service.Abstracts
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentListAsync();
        public Task<Student> GetStudentByIDWithIncludeAsync(int id);
        public Task<Student> GetByIDAsync(int id);
        public Task<string> AddAsync(Student student);
        public Task<bool> IsNameArExist(string name);
        public Task<bool> IsNameEnExist(string name);
        public Task<bool> IsNameArExistExludeSelf(string nameAr, int id);
        public Task<bool> IsNameEnExistExludeSelf(string nameEn, int id);
        public Task<string> EditAsync(Student student);
        public Task<string> DeleteAsync(Student student);
        public IQueryable<Student> GetStudentQuerable();
        public IQueryable<Student> GetStudentByDepartmentQuerable(int DID);
        public IQueryable<Student> FilterStudentPaginationQuerable(StudentOrderingEnum orderEnum, string search);

    }
}
