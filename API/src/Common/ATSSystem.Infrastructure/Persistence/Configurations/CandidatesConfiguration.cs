using ATSSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ATSSystem.Infrastructure.Persistence.Configurations
{
    public class CandidatesConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(t => t.FirstName)
                        .HasMaxLength(50)
                        .IsRequired();

            builder.Property(t => t.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.BirthDate)
                .IsRequired();

            builder.Property(t => t.Phone)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(t => t.Curriculum);
        }
    }
}
