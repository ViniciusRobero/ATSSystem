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

            RuleFor(v => v.FirstName)
                .MaximumLength(50).WithMessage("FirstName must not exceed 200 characters.")
                .NotEmpty().WithMessage("FirstName is required.");

            RuleFor(v => v.LastName)
                .MaximumLength(15).WithMessage("LastName must not exceed 15 characters.")
                .NotEmpty().WithMessage("LastName is required.");

            RuleFor(v => v.Email)
                .MaximumLength(15).WithMessage("Email must not exceed 10 characters.")
                .NotEmpty().WithMessage("Phone is required.");

        }
    }
}
