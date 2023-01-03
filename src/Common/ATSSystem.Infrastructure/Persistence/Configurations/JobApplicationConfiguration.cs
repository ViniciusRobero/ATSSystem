using ATSSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ATSSystem.Infrastructure.Persistence.Configurations
{
    public class JobApplicationConfiguration : IEntityTypeConfiguration<JobApplication>
    {
        public void Configure(EntityTypeBuilder<JobApplication> builder)
        {

            builder.Property(t => t.CandidateId)
                .IsRequired();

            builder.Property(t => t.JobId)
                .IsRequired();
        }
    }
}
