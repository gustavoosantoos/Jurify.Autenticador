using FluentValidation;
using Jurify.Autenticador.Web.UseCases.Offices.Create;

namespace Jurify.Autenticador.Web.UseCases.Offices.Availability
{
    public class CheckOfficeAvailabilityQueryValidator : AbstractValidator<CheckOfficeAvailabilityQuery>
    {
        public CheckOfficeAvailabilityQueryValidator()
        {
            RuleFor(query => query.OfficeName)
                .NotEmpty().WithMessage(CreateOfficeCommandValidator.OfficeNameEmptyErrorMessage)
                .Length(1, 100).WithMessage(CreateOfficeCommandValidator.OfficeNameLengthErrorMessage);
        }
    }
}
