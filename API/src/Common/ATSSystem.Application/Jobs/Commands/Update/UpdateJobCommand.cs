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
    public class UpdateJobCommand : IRequestWrapper<JobsDto>
    {
        public int Id { get; set; }

        public string JobTitle { get; set; }

        public string JobDiscription { get; set; }

        public string Seniority { get; set; }

        public decimal Salary { get; set; }

        public string Curriculum { get; set; }
    }

    public class UpdateJobCommandHandler : IRequestHandlerWrapper<UpdateJobCommand, JobsDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateJobCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<JobsDto>> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Jobs.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Job), request.Id);
            }

            if (!string.IsNullOrEmpty(request.JobTitle))
                entity.JobTitle = request.JobTitle;

            if (!string.IsNullOrEmpty(request.JobDiscription))
                entity.JobDiscription = request.JobDiscription;

            if (!string.IsNullOrEmpty(request.Seniority))
                entity.Seniority = request.Seniority;

            if (!string.IsNullOrEmpty(request.Seniority))
                entity.Seniority = request.Seniority;

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<JobsDto>(entity));
        }
    }
}
