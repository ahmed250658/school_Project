using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using school_Project.Data.Command;

namespace school_Project.Data.Entities
{
    public class Instructor : GenrelLocalizablEntity
    {
        public Instructor()
        {
            Instructors = new HashSet<Instructor>();
            Instructor_Subjects = new HashSet<Ins_Subject>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InsID { get; set; }
        public string? ENameAr { get; set; }
        public string? ENameEn { get; set; }
        public string? Address { get; set; }
        public string? Position { get; set; }
        public int? SupervisorId { get; set; }
        public decimal? Salary { get; set; }
        public string? Image { get; set; }

        public int DID { get; set; }
        [ForeignKey(nameof(DID))]
        [InverseProperty("Instructors")]
        public Department? department { get; set; }
        [InverseProperty("Instructor")]
        public Department? departmentManager { get; set; }


        [ForeignKey("SupervisorId")]
        [InverseProperty("Instructors")]
        public Instructor? Supervisor { get; set; }
        [InverseProperty("Supervisor")]
        public virtual ICollection<Instructor> Instructors { get; set; }
        [InverseProperty("Instructor")]
        public virtual ICollection<Ins_Subject> Instructor_Subjects { get; set; }

    }
}
