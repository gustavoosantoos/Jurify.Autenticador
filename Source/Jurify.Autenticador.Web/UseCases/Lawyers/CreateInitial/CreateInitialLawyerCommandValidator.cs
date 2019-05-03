using FluentValidation;
using Jurify.Autenticador.Web.UseCases.Offices.Create;

namespace Jurify.Autenticador.Web.UseCases.Lawyers.CreateInitial
{
    public class CreateInitialLawyerCommandValidator : AbstractValidator<CreateInitialLawyerCommand>
    {
        public CreateInitialLawyerCommandValidator()
        {
            RuleFor(e => e.CreateOfficeCommand).SetValidator(new CreateOfficeCommandValidator());
                
            RuleFor(e => e.Username)
                .NotEmpty().WithMessage("É obrigatório informar o e-mail do usuário")
                .Length(1, 150).WithMessage("O e-mail do usuário deve possuir no máximo 150 caracteres");

            RuleFor(e => e.PlainPassword)
                .NotEmpty().WithMessage("É obrigatório informar uma senha para o usuário");

            RuleFor(e => e.FirstName)
                .NotEmpty().WithMessage("É obrigatório informar o primeiro nome do usuário")
                .Length(1, 100).WithMessage("O primeiro nome do usuário deve possuir no máximo 100 caracteres");

            RuleFor(e => e.LastName)
                .NotEmpty().WithMessage("É obrigatório informar o último nome do usuário")
                .Length(1, 250).WithMessage("O primeiro nome do usuário deve possuir no máximo 250 caracteres");
        }
    }
}
