using FluentValidation;
using Jurify.Autenticador.Web.UseCases.Offices.Create;

namespace Jurify.Autenticador.Web.UseCases.Lawyers.CreateInitial
{
    public class CreateInitialLawyerCommandValidator : AbstractValidator<CreateInitialLawyerCommand>
    {
        public const string RequiredUsernameErrorMessage = "É obrigatório informar o e-mail do usuário";
        public const string UsernameLengthErrorMessage = "O e-mail do usuário deve possuir no máximo 150 caracteres";

        public const string RequiredPasswordErrorMessage = "É obrigatório informar uma senha para o usuário";

        public const string RequiredFirstNameErrorMessage = "É obrigatório informar o primeiro nome do usuário";
        public const string FirstNameLengthErrorMessage = "O primeiro nome do usuário deve possuir no máximo 100 caracteres";

        public const string RequiredLastNameErrorMessage = "É obrigatório informar o último nome do usuário";
        public const string LastNameLengthErrorMessage = "O primeiro nome do usuário deve possuir no máximo 250 caracteres";

        public CreateInitialLawyerCommandValidator()
        {
            RuleFor(e => e.CreateOfficeCommand).SetValidator(new CreateOfficeCommandValidator());
                
            RuleFor(e => e.Username)
                .NotEmpty().WithMessage(RequiredUsernameErrorMessage)
                .Length(1, 150).WithMessage(UsernameLengthErrorMessage);

            RuleFor(e => e.PlainPassword)
                .NotEmpty().WithMessage(RequiredPasswordErrorMessage);

            RuleFor(e => e.FirstName)
                .NotEmpty().WithMessage(RequiredFirstNameErrorMessage)
                .Length(1, 100).WithMessage(FirstNameLengthErrorMessage);

            RuleFor(e => e.LastName)
                .NotEmpty().WithMessage(RequiredLastNameErrorMessage)
                .Length(1, 250).WithMessage(LastNameLengthErrorMessage);
        }
    }
}
