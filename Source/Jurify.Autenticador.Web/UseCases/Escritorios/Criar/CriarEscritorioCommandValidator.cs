using FluentValidation;

namespace Jurify.Autenticador.Web.UseCases.Offices.Create
{
    public class CriarEscritorioCommandValidator : AbstractValidator<CriarEscritorioCommand>
    {
        public const string OfficeNameEmptyErrorMessage = "O nome do escritório deve ser informado";
        public const string OfficeNameLengthErrorMessage = "O nome do escritório deve ter ao máximo 100 caracteres";

        public CriarEscritorioCommandValidator()
        {
            RuleFor(e => e.RazaoSocial)
                .NotEmpty().WithMessage(OfficeNameEmptyErrorMessage)
                .Length(1, 100).WithMessage(OfficeNameLengthErrorMessage);
        }
    }
}
