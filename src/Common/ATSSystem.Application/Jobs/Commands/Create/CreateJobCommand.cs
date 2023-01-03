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
    public record CreateJobCommand(string JobTitle, string JobDiscription, string Seniority, decimal Salary, string Curriculum) : IRequestWrapper<JobsDto>;

    public class CreateJobCommandHandler : IRequestHandlerWrapper<CreateJobCommand, JobsDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateJobCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<JobsDto>> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            var entity = new Job
            {
                JobDiscription = request.JobDiscription,
                JobTitle = request.JobTitle,
                Salary = request.Salary,
                Seniority = request.Seniority,
                Curriculum = request.Curriculum
            };

            await _context.Jobs.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<JobsDto>(entity));
        }
    }
}
