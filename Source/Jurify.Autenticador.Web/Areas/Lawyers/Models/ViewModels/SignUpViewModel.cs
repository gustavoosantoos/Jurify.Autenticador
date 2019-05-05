using Jurify.Autenticador.Web.Areas.Lawyers.Models.InputModels;
using Jurify.Autenticador.Web.UseCases.Lawyers.CreateInitial;
using Jurify.Autenticador.Web.UseCases.Offices.Create;
using System.ComponentModel.DataAnnotations;

namespace Jurify.Autenticador.Web.Areas.Lawyers.Models.ViewModels
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = CreateOfficeCommandValidator.OfficeNameEmptyErrorMessage)]
        [StringLength(100, ErrorMessage = CreateOfficeCommandValidator.OfficeNameLengthErrorMessage)]
        public string OfficeName { get; set; }

        [Required(ErrorMessage = "A latitude do escritório deve ser informada")]
        [Range(-90, 90, ErrorMessage = CreateOfficeCommandValidator.LatitudeRangeErrorMessage)]
        public double? Latitude { get; set; }

        [Required(ErrorMessage = "A longitude do escritório deve ser informada")]
        [Range(-180, 180, ErrorMessage = CreateOfficeCommandValidator.LongitudeRangeErrorMessage)]
        public double? Longitude { get; set; }

        [Required(ErrorMessage = CreateInitialLawyerCommandValidator.RequiredFirstNameErrorMessage)]
        [StringLength(100, ErrorMessage = CreateInitialLawyerCommandValidator.FirstNameLengthErrorMessage)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = CreateInitialLawyerCommandValidator.RequiredLastNameErrorMessage)]
        [StringLength(250, ErrorMessage = CreateInitialLawyerCommandValidator.LastNameLengthErrorMessage)]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "O e-mail deve estar em um formato válido")]
        [Required(ErrorMessage = CreateInitialLawyerCommandValidator.RequiredUsernameErrorMessage)]
        [StringLength(150, ErrorMessage = CreateInitialLawyerCommandValidator.UsernameLengthErrorMessage)]
        public string Email { get; set; }

        [Required(ErrorMessage = CreateInitialLawyerCommandValidator.RequiredPasswordErrorMessage)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "É necessário confirmar a senha escolhida")]
        [Compare("Password", ErrorMessage = "As senhas não conferem")]
        public string ConfirmPassword { get; set; }

        public string ReturnUrl { get; set; }
    }
}
