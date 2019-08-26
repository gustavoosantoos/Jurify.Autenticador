using Jurify.Autenticador.Web.UseCases.Lawyers.CreateInitial;
using Jurify.Autenticador.Web.UseCases.Offices.Create;
using System.ComponentModel.DataAnnotations;

namespace Jurify.Autenticador.Web.Areas.Lawyers.Models
{
    public class SignUpInputModel
    {
        public string OfficeName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
