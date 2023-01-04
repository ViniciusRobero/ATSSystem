using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ATSSystem.Application.Common.Interfaces;
using ATSSystem.Application.Common.Models;
using ATSSystem.Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ATSSystem.Application.Jobs.Queries.GetJobs
{
    public class GetAllJobsQuery : IRequestWrapper<List<JobsDto>>
    {

    }

    public class GetJobsQueryHandler : IRequestHandlerWrapper<GetAllJobsQuery, List<JobsDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetJobsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<JobsDto>>> Handle(GetAllJobsQuery request, CancellationToken cancellationToken)
        {
            List<JobsDto> list = await _context.Jobs
                .ProjectToType<JobsDto>(_mapper.Config)
                .ToListAsync(cancellationToken);

            return list.Count > 0 ? ServiceResult.Success(list) : ServiceResult.Failed<List<JobsDto>>(ServiceError.NotFound);
        }
    }
}
