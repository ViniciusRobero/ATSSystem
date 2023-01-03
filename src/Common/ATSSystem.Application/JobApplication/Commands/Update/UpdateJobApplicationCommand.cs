using System.Threading;
using System.Threading.Tasks;
using ATSSystem.Application.Common.Exceptions;
using ATSSystem.Application.Common.Interfaces;
using ATSSystem.Application.Common.Models;
using ATSSystem.Application.Dto;
using ATSSystem.Domain.Entities;
using MapsterMapper;

namespace ATSSystem.Application.Jobs.Commands.Update
{
    public class UpdateJobApplicationCommand : IRequestWrapper<JobApplicationDto>
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public int CandidateId { get; set; }
        public int CreateAt { get; set; }
        public bool Active { get; set; }
    }

    public class UpdateJobApplicationCommandHandler : IRequestHandlerWrapper<UpdateJobApplicationCommand, JobApplicationDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateJobApplicationCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<JobApplicationDto>> Handle(UpdateJobApplicationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.JobApplication.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(JobApplication), request.Id);
            }

            if (request.CandidateId != 0)
                entity.CandidateId = request.CandidateId;

            if (request.JobId != 0)
                entity.JobId = request.JobId;

                entity.Active = request.Active;

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<JobApplicationDto>(entity));
        }
    }
}
