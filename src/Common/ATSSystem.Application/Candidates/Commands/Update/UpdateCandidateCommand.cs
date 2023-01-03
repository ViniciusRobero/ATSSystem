using System;
using System.Threading;
using System.Threading.Tasks;
using ATSSystem.Application.Common.Exceptions;
using ATSSystem.Application.Common.Interfaces;
using ATSSystem.Application.Common.Models;
using ATSSystem.Application.Dto;
using ATSSystem.Domain.Entities;
using MapsterMapper;

namespace ATSSystem.Application.Candidates.Commands.Update
{
    public class UpdateCandidateCommand : IRequestWrapper<CandidatesDto>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Document { get; set; }

        public DateTime BirthDate { get; set; }

        public string Occupation { get; set; }

        public string Seniority { get; set; }

    }

    public class UpdateCandidateCommandHandler : IRequestHandlerWrapper<UpdateCandidateCommand, CandidatesDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateCandidateCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<CandidatesDto>> Handle(UpdateCandidateCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Candidates.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Candidate), request.Id);
            }
            if (!string.IsNullOrEmpty(request.Name))
                entity.Name = request.Name;

            if (!string.IsNullOrEmpty(request.Document))
                entity.Document = request.Document;

            if (!string.IsNullOrEmpty(request.Occupation))
                entity.Occupation = request.Occupation;

            if (!string.IsNullOrEmpty(request.Seniority))
                entity.Seniority = request.Seniority;

            if (request.BirthDate != DateTime.MinValue)
                entity.BirthDate = request.BirthDate;

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<CandidatesDto>(entity));
        }
    }
}
