using System.Threading;
using System.Threading.Tasks;
using ATSSystem.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ATSSystem.Application.Candidates.Commands.Create
{
    public class CreateCandidateCommandValidator : AbstractValidator<CreateCandidateCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateCandidateCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Name)
                .MaximumLength(200).WithMessage("Name must not exceed 200 characters.")
                .NotEmpty().WithMessage("Name is required.");
        
            RuleFor(v => v.Document)
                .MaximumLength(15).WithMessage("Document must not exceed 15 characters.")
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(v => v.BirthDate)
                .NotEmpty().WithMessage("BirthDate is required.");

            RuleFor(v => v.Seniority)
                .MaximumLength(10).WithMessage("Seniority must not exceed 10 characters.")
                .NotEmpty().WithMessage("Seniority is required.");

            RuleFor(v => v.Occupation)
                .MaximumLength(30).WithMessage("Occupation must not exceed 30 characters.")
                .NotEmpty().WithMessage("Occupation is required.");
        }
    }
}
