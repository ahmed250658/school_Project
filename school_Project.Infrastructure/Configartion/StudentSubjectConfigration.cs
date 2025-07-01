using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using school_Project.Data.Entities;

namespace school_Project.Infrastructure.Configartion
{
    public class StudentSubjectConfigration : IEntityTypeConfiguration<StudentSubject>
    {
        public void Configure(EntityTypeBuilder<StudentSubject> builder)
        {
            builder.HasKey(x => new { x.SubID, x.StudID });

            builder.HasOne(x => x.Student).
                    WithMany(c => c.studentSubjects).
                    HasForeignKey(v => v.StudID);


            builder.HasOne(x => x.Subject).
                    WithMany(c => c.StudentsSubjects).
                    HasForeignKey(v => v.SubID);

        }


    }
}
