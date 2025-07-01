using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using school_Project.Data.Entities;

namespace school_Project.Infrastructure.Configartion
{
    public class DepartmentConfigration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {

            builder.HasMany(x => x.Students).
              WithOne(c => c.Department).
              HasForeignKey(d => d.DID).
              OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Instructor)
            .WithOne(x => x.departmentManager)
            .HasForeignKey<Department>(x => x.InsManager)
             .OnDelete(DeleteBehavior.Restrict); ;

        }
    }
}
