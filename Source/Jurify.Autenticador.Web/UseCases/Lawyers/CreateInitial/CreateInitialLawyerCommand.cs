using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.UseCases.Core;
using Jurify.Autenticador.Web.UseCases.Offices.Create;
using MediatR;

namespace Jurify.Autenticador.Web.UseCases.Lawyers.CreateInitial
{
    public class CreateInitialLawyerCommand : IRequest<Response<UsuarioEscritorio>>
    {
        public CreateInitialLawyerCommand()
        {
        }

        public CreateInitialLawyerCommand(
            string officeName,
            string username,
            string plainPassword,
            string firstName,
            string lastName)
        {
            OfficeName = officeName;
            Username = username;
            PlainPassword = plainPassword;
            FirstName = firstName;
            LastName = lastName;
        }

        public string OfficeName { get; set; }

        public string Username { get; set; }
        public string PlainPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public CreateOfficeCommand CreateOfficeCommand =>
            new CreateOfficeCommand()
            {
                RazaoSocial = OfficeName
            };
    }
}
