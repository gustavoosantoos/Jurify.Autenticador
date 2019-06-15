using FluentValidation;
using Jurify.Autenticador.Web.UseCases.Lawyers.CreateInitial;

namespace Jurify.Autenticador.Web.UseCases.Lawyers.Availability
{
    public class CheckLawyerAvailabilityQueryValidator : AbstractValidator<CheckLawyerAvailabilityQuery>
    {
        public CheckLawyerAvailabilityQueryValidator()
        {
            RuleFor(q => q.Username)
                .NotEmpty().WithMessage(CreateInitialLawyerCommandValidator.RequiredUsernameErrorMessage)
                .MaximumLength(150).WithMessage(CreateInitialLawyerCommandValidator.UsernameLengthErrorMessage)
                .EmailAddress().WithMessage(CreateInitialLawyerCommandValidator.UsernameValidEmailMessage);
        }
    }
}
