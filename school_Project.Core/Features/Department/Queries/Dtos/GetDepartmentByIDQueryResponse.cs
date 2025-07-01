using school_Project.Core.Pagination;

namespace school_Project.Core.Features.Department.Queries.Dtos
{
    public class GetDepartmentByIDQueryResponse
    {
        public int ID { get; set; }
        public string DName { get; set; }
        public string ManagerName { get; set; }
        public PaginatedResult<StudentResponse>? StudentList { get; set; }
        public List<SubjectResponse>? SubjectList { get; set; }
        public List<InstructorResponse>? InstructorList { get; set; }


    }
    public class StudentResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public StudentResponse(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
    public class SubjectResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class InstructorResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}