using System.Threading;
using System.Threading.Tasks;
using ATSSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ATSSystem.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Candidate> Candidates { get; set; }
        DbSet<Job> Jobs { get; set; }
        DbSet<JobApplication> JobApplication { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
