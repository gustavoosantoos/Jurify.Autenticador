using FluentValidation;

namespace Jurify.Autenticador.Web.UseCases.Offices.Create
{
    public class CreateOfficeCommandValidator : AbstractValidator<CreateOfficeCommand>
    {
        public CreateOfficeCommandValidator()
        {
        }
    }
}
