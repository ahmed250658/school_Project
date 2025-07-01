using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace school_Project.Data.Entities
{
    public class Ins_Subject
    {
        [Key]
        public int InsID { get; set; }
        [Key]
        public int SubID { get; set; }
        [ForeignKey(nameof(InsID))]
        [InverseProperty("Instructor_Subjects")]
        public Instructor? Instructor { get; set; }
        [ForeignKey(nameof(SubID))]
        [InverseProperty("Ins_Subjects")]
        public Subjects? Subjects { get; set; }
    }
}
