using FluentValidation;

namespace Jurify.Autenticador.Web.UseCases.Offices.Availability
{
    public class CheckOfficeAvailabilityQueryValidator : AbstractValidator<CheckOfficeAvailabilityQuery>
    {
        public CheckOfficeAvailabilityQueryValidator()
        {
            RuleFor(query => query.OfficeName);
        }
    }
}
