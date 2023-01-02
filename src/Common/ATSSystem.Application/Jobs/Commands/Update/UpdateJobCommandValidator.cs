using ATSSystem.Application.Common.Interfaces;
using FluentValidation;

namespace ATSSystem.Application.Jobs.Commands.Update
{
    public class UpdateJobCommandValidator : AbstractValidator<UpdateJobCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateJobCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.JobTitle)
                .MaximumLength(100).WithMessage("JobTitle must not exceed 200 characters.")
                .NotEmpty().WithMessage("JobTitle is required.");

            RuleFor(v => v.JobDiscription)
                .NotEmpty().WithMessage("JobDiscription is required.");

            RuleFor(v => v.Salary)
                .NotEmpty().WithMessage("Salary is required.");

            RuleFor(v => v.Seniority)
                .MaximumLength(10).WithMessage("Seniority must not exceed 10 characters.")
                .NotEmpty().WithMessage("Seniority is required.");

            RuleFor(v => v.Id).NotNull();
        }
    }
}
