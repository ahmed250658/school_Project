using Microsoft.EntityFrameworkCore;
using school_Project.Data.Entities;
using school_Project.Data.Enums;
using school_Project.Infrastructure.Repository.Abstract;
using school_Project.Service.Abstracts;

namespace school_Project.Service.Impelementions
{
    public class StudentService : IStudentService
    {
        #region Fields
        public readonly IStrudentRepository _studentrepository;
        #endregion

        #region Constructure
        public StudentService(IStrudentRepository studentrepository)
        {
            _studentrepository = studentrepository;
        }

        #endregion

        #region Handels Functions
        public Task<List<Student>> GetStudentListAsync()
        {
            return _studentrepository.GetStudentListAsync();
        }

        public async Task<Student> GetStudentByIDWithIncludeAsync(int id)
        {
            var student = _studentrepository.GetTableAsTracking().
                                            Include(x => x.Department)
                                            .Where(u => u.StudID.Equals(id)).
                                            FirstOrDefault();
            return student;
        }

        public async Task<string> AddAsync(Student student)
        {
            //Add the sudent
            await _studentrepository.AddAsync(student);
            return "Success";
        }

        public async Task<bool> IsNameArExist(string name)
        {
            // check if the name of student is found
            var stud = _studentrepository.GetTableNoTracking().Where(x => x.NameAr.Equals(name)).FirstOrDefault();
            if (stud == null) return false;
            return true;
        }
        public async Task<bool> IsNameEnExist(string name)
        {
            // check if the name of student is found
            var stud = _studentrepository.GetTableNoTracking().Where(x => x.NameEn.Equals(name)).FirstOrDefault();
            if (stud == null) return false;
            return true;
        }

        public async Task<bool> IsNameArExistExludeSelf(string nameAr, int id)
        {
            // check if the name of student is found
            var stud = await _studentrepository.GetTableNoTracking().Where(x => x.NameAr.Equals(nameAr) & x.StudID.Equals(id)).FirstOrDefaultAsync();
            if (stud == null) return false;
            return true;
        }
        public async Task<bool> IsNameEnExistExludeSelf(string nameEn, int id)
        {
            // check if the name of student is found
            var stud = await _studentrepository.GetTableNoTracking().Where(x => x.NameEn.Equals(nameEn) & x.StudID.Equals(id)).FirstOrDefaultAsync();
            if (stud == null) return false;
            return true;
        }

        public async Task<string> EditAsync(Student student)
        {
            await _studentrepository.UpdateAsync(student);
            return "Success";
        }

        public async Task<string> DeleteAsync(Student student)
        {
            var tran = _studentrepository.BeginTransaction();
            try
            {
                await _studentrepository.DeleteAsync(student);
                await tran.CommitAsync();
                return "Success";
            }
            catch
            {
                await tran.RollbackAsync();
                return "Falied";
            }

        }

        public Task<Student> GetByIDAsync(int id)
        {
            var student = _studentrepository.GetByIdAsync(id);
            return student;
        }

        public IQueryable<Student> GetStudentQuerable()
        {
            return _studentrepository.GetTableNoTracking().Include(x => x.Department).AsQueryable();
        }

        public IQueryable<Student> FilterStudentPaginationQuerable(StudentOrderingEnum orderEnum, string search)
        {

            var querable = _studentrepository.GetTableNoTracking().Include(x => x.Department).AsQueryable();
            if (search != null)
            {
                querable = querable.Where(x => x.NameAr.Contains(search) || x.Address.Contains(search));
            }
            switch (orderEnum)
            {
                case StudentOrderingEnum.StudID:
                    querable = querable.OrderBy(x => x.StudID);
                    break;
                case StudentOrderingEnum.Name:
                    querable = querable.OrderBy(x => x.NameAr);
                    break;
                case StudentOrderingEnum.Address:
                    querable = querable.OrderBy(x => x.Address);
                    break;
                case StudentOrderingEnum.DepartmentName:
                    querable = querable.OrderBy(x => x.Department.DNameAr);
                    break;
            }
            return querable;

        }

        public IQueryable<Student> GetStudentByDepartmentQuerable(int DID)
        {
            return _studentrepository.GetTableNoTracking().Where(x => x.DID.Equals(DID)).AsQueryable();
        }

        #endregion
    }
}
