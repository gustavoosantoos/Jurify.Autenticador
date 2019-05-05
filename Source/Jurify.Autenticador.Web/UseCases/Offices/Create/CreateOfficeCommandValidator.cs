using FluentValidation;

namespace Jurify.Autenticador.Web.UseCases.Offices.Create
{
    public class CreateOfficeCommandValidator : AbstractValidator<CreateOfficeCommand>
    {
        public const string OfficeNameEmptyErrorMessage = "O nome do escritório deve ser informado";
        public const string OfficeNameLengthErrorMessage = "O nome do escritório deve ter ao máximo 100 caracteres";

        public const string LongitudeRangeErrorMessage = "A longitude deve estar entre -180 e 180 graus";
        public const string LatitudeRangeErrorMessage = "A latitude deve estar entre -90 e 90 graus";

        public CreateOfficeCommandValidator()
        {
            RuleFor(e => e.OfficeName)
                .NotEmpty().WithMessage(OfficeNameEmptyErrorMessage)
                .Length(1, 100).WithMessage(OfficeNameLengthErrorMessage);

            RuleFor(e => e.Latitude)
                .GreaterThanOrEqualTo(-90).WithMessage(LatitudeRangeErrorMessage)
                .LessThanOrEqualTo(90).WithMessage(LatitudeRangeErrorMessage);

            RuleFor(e => e.Longitude)
                .GreaterThanOrEqualTo(-180).WithMessage(LongitudeRangeErrorMessage)
                .LessThanOrEqualTo(180).WithMessage(LongitudeRangeErrorMessage);
        }
    }
}
