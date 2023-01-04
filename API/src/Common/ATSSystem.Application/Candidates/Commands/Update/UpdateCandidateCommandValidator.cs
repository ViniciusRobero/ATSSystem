using System.Threading;
using System.Threading.Tasks;
using ATSSystem.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ATSSystem.Application.Candidates.Commands.Update
{
    public class UpdateCandidateCommandValidator : AbstractValidator<UpdateCandidateCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateCandidateCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.FirstName)
                .MaximumLength(50).WithMessage("FirstName must not exceed 200 characters.")
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(v => v.LastName)
                .MaximumLength(50).WithMessage("LastName must not exceed 15 characters.")
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(v => v.BirthDate)
                .NotEmpty().WithMessage("BirthDate is required.");

            RuleFor(v => v.Phone)
                .MaximumLength(15).WithMessage("Phone must not exceed 10 characters.")
                .NotEmpty().WithMessage("Seniority is required.");

            RuleFor(v => v.Id).NotNull();
        }
    }
}
