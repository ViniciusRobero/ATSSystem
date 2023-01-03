using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ATSSystem.Application.Common.Interfaces;
using ATSSystem.Application.Common.Models;
using ATSSystem.Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ATSSystem.Application.Jobs.Queries.GetJobsById
{
    public class GetJobByIdQuery : IRequestWrapper<JobsDto>
    {
        public int JobId { get; set; }
    }

    public class GetJobByIdQueryHandler : IRequestHandlerWrapper<GetJobByIdQuery, JobsDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetJobByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<JobsDto>> Handle(GetJobByIdQuery request, CancellationToken cancellationToken)
        {
            var candidate = await _context.Candidates
                .Where(x => x.Id == request.JobId)
                .ProjectToType<JobsDto>(_mapper.Config)
                .FirstOrDefaultAsync(cancellationToken);

            return candidate != null ? ServiceResult.Success(candidate) : ServiceResult.Failed<JobsDto>(ServiceError.NotFound);
        }
    }
}
