using System;
using System.Threading;
using System.Threading.Tasks;
using ATSSystem.Application.Common.Interfaces;
using ATSSystem.Application.Common.Models;
using ATSSystem.Application.Dto;
using ATSSystem.Domain.Entities;
using MapsterMapper;

namespace ATSSystem.Application.Jobs.Commands.Create
{
    public record CreateJobApplicationCommand(int Id, int JobId, int CandidateId) : IRequestWrapper<JobApplicationDto>;

    public class CreateJobApplicationCommandHandler : IRequestHandlerWrapper<CreateJobApplicationCommand, JobApplicationDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateJobApplicationCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<JobApplicationDto>> Handle(CreateJobApplicationCommand request, CancellationToken cancellationToken)
        {
            var entity = new JobApplication
            {
                CandidateId = request.CandidateId,
                Active = true,
                CreateAt = DateTime.Now,
                JobId = request.JobId,
            };

            await _context.JobApplication.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<JobApplicationDto>(entity));
        }
    }
}
