using Microsoft.EntityFrameworkCore;
using school_Project.Data.Entities;
using school_Project.Infrastructure.Base;
using school_Project.Infrastructure.Data;
using school_Project.Infrastructure.Repository.Abstract;

namespace school_Project.Infrastructure.Repository.Impelement
{
    public class StudentRepository : GenericRepositoryAsync<Student>, IStrudentRepository
    {
        #region fileds
        public readonly DbSet<Student> _students;
        #endregion

        #region Constructure
        public StudentRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
            _students = dbcontext.Set<Student>();
        }
        #endregion
        #region Handels Functions
        public async Task<List<Student>> GetStudentListAsync()
        {
            return await _students.Include(x => x.Department).ToListAsync();
        }
        #endregion
    }
}
