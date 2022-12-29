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

            RuleFor(v => v.Name)
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.")
                .MustAsync(BeUniqueName).WithMessage("The specified candidate already exists. If you just want to activate the candidate leave the name field blank!");

            RuleFor(v => v.Id).NotNull();
        }

        private async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            //TODO: Control by uppercase and CultureInfo
            return await _context.Candidates.AllAsync(x => x.Name != name, cancellationToken);
        }
    }
}
