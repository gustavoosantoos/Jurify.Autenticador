namespace Jurify.Autenticador.Web.Domain.Model.Services.Abstractions
{
    public interface IHashService
    {
        string Hash(string source);
        bool Verify(string hash, string password);
    }
}
