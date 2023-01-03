using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ATSSystem.Application.Common.Interfaces;
using ATSSystem.Application.Common.Models;
using ATSSystem.Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ATSSystem.Application.Candidates.Queries.GetCandidateById
{
    public class GetCandidateByIdQuery : IRequestWrapper<CandidatesDto>
    {
        public int CandidateId { get; set; }
    }

    public class GetCandidateByIdQueryHandler : IRequestHandlerWrapper<GetCandidateByIdQuery, CandidatesDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCandidateByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<CandidatesDto>> Handle(GetCandidateByIdQuery request, CancellationToken cancellationToken)
        {
            var candidate = await _context.Candidates
                .Where(x => x.Id == request.CandidateId)
                .ProjectToType<CandidatesDto>(_mapper.Config)
                .FirstOrDefaultAsync(cancellationToken);

            return candidate != null ? ServiceResult.Success(candidate) : ServiceResult.Failed<CandidatesDto>(ServiceError.NotFound);
        }
    }
}
