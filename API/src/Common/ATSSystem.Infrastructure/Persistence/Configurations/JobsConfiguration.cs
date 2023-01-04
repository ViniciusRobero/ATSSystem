using ATSSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ATSSystem.Infrastructure.Persistence.Configurations
{
    public class JobsConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(t => t.JobTitle)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.JobDiscription)
                .IsRequired();

            builder.Property(t => t.Salary)
                .IsRequired();

            builder.Property(t => t.Seniority)
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}
