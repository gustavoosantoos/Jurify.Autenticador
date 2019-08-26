using FluentValidation;
using Jurify.Autenticador.Web.UseCases.Lawyers.CreateInitial;

namespace Jurify.Autenticador.Web.UseCases.Lawyers.Availability
{
    public class DisponibilidadeAdvogadoQueryValidator : AbstractValidator<DisponibilidadeAdvogadoQuery>
    {
        public DisponibilidadeAdvogadoQueryValidator()
        {
            RuleFor(q => q.Username)
                .NotEmpty().WithMessage(CriarUsuarioInicialCommandValidator.RequiredUsernameErrorMessage)
                .MaximumLength(150).WithMessage(CriarUsuarioInicialCommandValidator.UsernameLengthErrorMessage)
                .EmailAddress().WithMessage(CriarUsuarioInicialCommandValidator.UsernameValidEmailMessage);
        }
    }
}
