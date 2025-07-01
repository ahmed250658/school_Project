using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using school_Project.Data.Entities;

namespace school_Project.Infrastructure.Configartion
{
    public class InstructorConfigration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {

            builder.HasOne(x => x.Supervisor).
                    WithMany(x => x.Instructors).
                    HasForeignKey(x => x.SupervisorId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
