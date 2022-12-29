using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ATSSystem.Application.Common.Interfaces;
using ATSSystem.Application.Common.Models;
using ATSSystem.Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ATSSystem.Application.Candidates.Queries.GetCandidates
{
    public class GetAllCandidatesQuery : IRequestWrapper<List<CandidatesDto>>
    {

    }

    public class GetCandidatesQueryHandler : IRequestHandlerWrapper<GetAllCandidatesQuery, List<CandidatesDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCandidatesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<CandidatesDto>>> Handle(GetAllCandidatesQuery request, CancellationToken cancellationToken)
        {
            List<CandidatesDto> list = await _context.Candidates
                .ProjectToType<CandidatesDto>(_mapper.Config)
                .ToListAsync(cancellationToken);

            return list.Count > 0 ? ServiceResult.Success(list) : ServiceResult.Failed<List<CandidatesDto>>(ServiceError.NotFound);
        }
    }
}
