using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ATSSystem.Application.Common.Exceptions;
using ATSSystem.Application.Common.Interfaces;
using ATSSystem.Application.Common.Models;
using ATSSystem.Application.Dto;
using ATSSystem.Domain.Entities;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ATSSystem.Application.Candidates.Commands.Delete
{
    public class DeleteCandidateCommand : IRequestWrapper<CandidatesDto>
    {
        public int Id { get; set; }
    }

    public class DeleteCandidateCommandHandler : IRequestHandlerWrapper<DeleteCandidateCommand, CandidatesDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeleteCandidateCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<CandidatesDto>> Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Candidates
                .Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Candidate), request.Id);
            }

            _context.Candidates.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<CandidatesDto>(entity));
        }
    }
}
