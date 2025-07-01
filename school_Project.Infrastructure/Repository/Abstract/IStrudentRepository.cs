using school_Project.Data.Entities;
using school_Project.Infrastructure.Base;

namespace school_Project.Infrastructure.Repository.Abstract
{
    public interface IStrudentRepository : IGenericRepositoryAsync<Student>
    {
        public Task<List<Student>> GetStudentListAsync();
    }
}
