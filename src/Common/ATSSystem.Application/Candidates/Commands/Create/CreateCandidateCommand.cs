﻿using System;
using System.Threading;
using System.Threading.Tasks;
using ATSSystem.Application.Common.Interfaces;
using ATSSystem.Application.Common.Models;
using ATSSystem.Application.Dto;
using ATSSystem.Domain.Entities;
using MapsterMapper;

namespace ATSSystem.Application.Candidates.Commands.Create
{
    public record CreateCandidateCommand(string Name, string Document, DateTime BirthDate, string Ocupation, string Seniority, string Occupation) : IRequestWrapper<CandidatesDto>;

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
                Name = request.Name,
                Document = request.Document,
                BirthDate = request.BirthDate,
                Occupation = request.Ocupation,
                Seniority = request.Seniority
            };

            await _context.Candidates.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<CandidatesDto>(entity));
        }
    }
}
