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

namespace ATSSystem.Application.Jobs.Commands.Delete
{
    public class DeleteJobCommand : IRequestWrapper<JobsDto>
    {
        public int Id { get; set; }
    }

    public class DeleteJobCommandHandler : IRequestHandlerWrapper<DeleteJobCommand, JobsDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeleteJobCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<JobsDto>> Handle(DeleteJobCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Jobs
                .Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Job), request.Id);
            }

            _context.Jobs.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<JobsDto>(entity));
        }
    }
}
