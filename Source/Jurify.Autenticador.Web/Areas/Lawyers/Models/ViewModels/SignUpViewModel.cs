using Jurify.Autenticador.Web.Areas.Lawyers.Models.InputModels;

namespace Jurify.Autenticador.Web.Areas.Lawyers.Models.ViewModels
{
    public class SignUpViewModel : SignUpInputModel
    {
        public string ReturnUrl { get; set; }
    }
}
