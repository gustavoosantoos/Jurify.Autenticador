using Jurify.Autenticador.Web.Areas.Lawyers.Models.InputModels;

namespace Jurify.Autenticador.Web.Areas.Lawyers.Models.ViewModels
{
    public class LogoutViewModel : LogoutInputModel
    {
        public bool ShowLogoutPrompt { get; set; } = true;
    }
}
