namespace Jurify.Autenticador.Web.Areas.Lawyers.Models.InputModels
{
    public class SignUpInputModel
    {
        public string OfficeName { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}