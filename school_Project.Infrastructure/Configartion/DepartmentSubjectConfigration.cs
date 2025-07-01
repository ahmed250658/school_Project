using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using school_Project.Data.Entities;

namespace school_Project.Infrastructure.Configartion
{
    public class DepartmentSubjectConfigration : IEntityTypeConfiguration<DepartmetSubject>
    {
        public void Configure(EntityTypeBuilder<DepartmetSubject> builder)
        {
            builder.HasKey(x => new { x.SubID, x.DID });

            builder.HasOne(x => x.Department).
                    WithMany(c => c.DepartmentSubjects).
                    HasForeignKey(v => v.DID);


            builder.HasOne(x => x.Subjects).
                    WithMany(c => c.DepartmetsSubjects).
                    HasForeignKey(v => v.SubID);


        }
    }
}
