using FluentValidation;
using Jurify.Autenticador.Web.UseCases.Offices.Create;

namespace Jurify.Autenticador.Web.UseCases.Offices.Availability
{
    public class DisponibilidadeEscritorioQueryValidator : AbstractValidator<DisponibilidadeEscritorioQuery>
    {
        public DisponibilidadeEscritorioQueryValidator()
        {
            RuleFor(query => query.NomeFantasia)
                .NotEmpty().WithMessage(CriarEscritorioCommandValidator.OfficeNameEmptyErrorMessage)
                .Length(1, 100).WithMessage(CriarEscritorioCommandValidator.OfficeNameLengthErrorMessage);
        }
    }
}
