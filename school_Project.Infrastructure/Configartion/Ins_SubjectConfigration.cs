using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using school_Project.Data.Entities;

namespace school_Project.Infrastructure.Configartion
{
    public class Ins_SubjectConfigration : IEntityTypeConfiguration<Ins_Subject>
    {
        public void Configure(EntityTypeBuilder<Ins_Subject> builder)
        {
            builder.HasKey(x => new { x.SubID, x.InsID });

            builder.HasOne(x => x.Instructor).
                    WithMany(c => c.Instructor_Subjects).
                    HasForeignKey(v => v.InsID);


            builder.HasOne(x => x.Subjects).
                    WithMany(c => c.Ins_Subjects).
                    HasForeignKey(v => v.SubID);

        }
    }
}
