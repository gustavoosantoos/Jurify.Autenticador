namespace Jurify.Autenticador.Web.Features.Account
{
    public class SignUpViewModel
    {
        public string OfficeName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string ReturnUrl { get; set; }
    }
}
