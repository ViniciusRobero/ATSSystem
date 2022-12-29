using ATSSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ATSSystem.Infrastructure.Persistence.Configurations
{
    public class CandidatesConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {

            builder.Property(t => t.Name)
                .HasMaxLength(200)
                .IsRequired();


            builder.Property(t => t.Document)
                .HasMaxLength(15)
                .IsRequired();
        }
    }
}
