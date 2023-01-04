using System;
using System.Threading;
using System.Threading.Tasks;
using ATSSystem.Application.Common.Interfaces;
using ATSSystem.Application.Common.Models;
using ATSSystem.Application.Dto;
using ATSSystem.Domain.Entities;
using MapsterMapper;

namespace ATSSystem.Application.Candidates.Commands.Create
{
    public record CreateCandidateCommand(string FirstName, string LastName, string Phone, DateTime BirthDate, string Curriculum) : IRequestWrapper<CandidatesDto>;

    public class CreateCandidateCommandHandler : IRequestHandlerWrapper<CreateCandidateCommand, CandidatesDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateCandidateCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<CandidatesDto>> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
        {
            var entity = new Candidate
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDate = request.BirthDate,
                Curriculum = request.Curriculum,
                Phone = request.Phone
            };

            await _context.Candidates.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<CandidatesDto>(entity));
        }
    }
}
