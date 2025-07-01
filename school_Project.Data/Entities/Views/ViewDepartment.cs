using Microsoft.EntityFrameworkCore;
using school_Project.Data.Command;

namespace school_Project.Data.Entities.Views
{
    [Keyless] // You don't need a primary key for a view
    public class ViewDepartment : GenrelLocalizablEntity
    {
        public int DID { get; set; }
        public string? DNameAr { get; set; }
        public string? DNameEn { get; set; }
        public int StudentCount { get; set; }

    }
}
