using Jurify.Autenticador.Web.Features.Account;

namespace Jurify.Autenticador.Web.Features.Account
{
    public class LogoutViewModel : LogoutInputModel
    {
        public bool ShowLogoutPrompt { get; set; } = true;
    }
}
