using school_Project.Data.Command;

namespace school_Project.Data.Entities.Procedures
{
    // This class represents a stored procedure result for Department information
    public class DepartmentProc : GenrelLocalizablEntity
    {
        public int DID { get; set; }
        public string? DNameAr { get; set; }
        public string? DNameEn { get; set; }
        public int StudentCount { get; set; }
    }
    public class DepartmentProcParameter
    {
        public int DID { get; set; } = 0;
    }
}
