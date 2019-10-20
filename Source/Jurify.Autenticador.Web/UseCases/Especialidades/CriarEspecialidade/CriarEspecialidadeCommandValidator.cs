using FluentValidation;
using Jurify.Autenticador.Web.UseCases.Offices.Create;

namespace Jurify.Autenticador.Web.UseCases.Specialties.Create
{
    public class CriarEspecialidadeCommandValidator : AbstractValidator<CriarEspecialidadeCommand>
    {
        public const string RequiredNameErrorMessage = "É obrigatório informar o nome da especialidade.";
        public const string NameLengthErrorMessage = "O nome da especialidade deve possuir no máximo 100 caracteres.";

        public const string RequiredDescriptionErrorMessage = "É obrigatório informar a descricao da especialidade.";
        public const string DescriptionLengthErrorMessage = "O nome da especialidade deve possuir no máximo 100 caracteres.";

        public CriarEspecialidadeCommandValidator()
        {

            RuleFor(e => e.Especialidade.Nome)
                .NotEmpty().WithMessage(RequiredNameErrorMessage)
                .Length(1, 100).WithMessage(NameLengthErrorMessage);

            RuleFor(e => e.Especialidade.Descricao)
             .NotEmpty().WithMessage(RequiredDescriptionErrorMessage)
             .Length(1, 255).WithMessage(DescriptionLengthErrorMessage);

        }
    }
}
